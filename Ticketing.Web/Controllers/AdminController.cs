
using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

using System.Web.Mvc;
using Ticketing.Data.Persistence;
using Ticketing.Data.TicketModel.ViewModels;
using Ticketing.Data.ViewModels;
using Ticketing.Entity.TicketModel;
using Ticketing.Identity;

namespace Ticketing.Controllers
{

    //[Authorize(Roles="Admin")]

    public class AdminController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationUserManager UserManager;
        public AdminController(IUnitOfWork unitOfWork, ApplicationUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            UserManager = userManager;
        }


        // GET: Admin
        public ActionResult Index()
        {


            var model = new AdminViewModel
            {
                RoleViewModel = new RoleVM
                {
                    Roles = _unitOfWork.Roles.GetAll(),
                    Name = " "
                },
                AllowedDomainVM = new AllowedDomainRolesVM
                {
                    AllowedDomains = _unitOfWork.allowedDomains.GetAll(),
                    AllRoles = _unitOfWork.Roles.GetAll().Select(r => (string)r.Name).ToList(),
                    Message = ""
                }
            };
            return View(model);
        }


        //Get: get the user View
        [HttpGet]
        public ActionResult Users()
        {

            var model = UserManager.Users.Select(u => new UserVM
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                IsEmailVerified = u.EmailConfirmed,
                IsRegistrationApproved = u.IsApproved,
                Id = u.Id
            }).ToList();

            return View("Users/Users", model);
        }




        [HttpGet]
        public ActionResult GetUserDetails(string Id)
        {
            try
            {
                var u = UserManager.FindById(Id);
                var role = UserManager.GetRoles(u.Id).ToList();
                var AllRoles = _unitOfWork.Roles.GetAll();
                var model = new UserDetailsVM
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    IsEmailVerified = u.EmailConfirmed,
                    IsRegistrationApproved = u.IsApproved,
                    Id = u.Id,
                    MatriculationNumber = "22",
                    IsUserDisabled = u.IsuserDisabled,
                    UserRoles = role.Select(r => new UserRoleVM
                    {
                        RoleName = r
                    }).ToList(),

                    AllRoles = AllRoles.Select(r => (string)r.Name).ToList()



                };
                return View("Users/UserEdit", model);
            }
            catch (Exception e)
            {
                ViewBag.Message = "Failed to get User Details  " + e.Message;
                return View("Info");
            }




        }

        [HttpPost]
        public ActionResult UpdateUserRole(string UserID, string RoleName, string option)
        {
            if (ModelState.IsValid)
            {
                switch (option)
                {
                    case "selected":
                        UserManager.AddToRole(UserID, RoleName);
                        ViewBag.Message = "User Added to Role";
                        break;
                    case "deselected":
                        UserManager.RemoveFromRole(UserID, RoleName);
                        ViewBag.Message = "User Removed From Role";
                        break;
                    default:
                        ViewBag.Message = "No changes made";
                        break;


                }

                ViewBag.Message = "User Role saved successfully";
                return PartialView("UserInfoPopUp");
            }
            ViewBag.Message = "Something went wrong";
            return PartialView("UserInfoPopUp");
        }

        [HttpPost]
        public async Task<ActionResult> EditUserDetails(UserDetailsVM model)
        {

            if (ModelState.IsValid)
            {

                var toBeUpdatedUser = UserManager.FindById(model.Id);
                toBeUpdatedUser.IsApproved = model.IsRegistrationApproved;
                toBeUpdatedUser.EmailConfirmed = model.IsEmailVerified;
                toBeUpdatedUser.IsuserDisabled = model.IsUserDisabled;
                await UserManager.UpdateAsync(toBeUpdatedUser);

                //await UserManager.SetLockoutEnabledAsync(toBeUpdatedUser.Id, model.IsUserDisabled);
                //await UserManager.SetLockoutEndDateAsync(toBeUpdatedUser.Id, DateTime.Today.AddYears(10));

                var user = await UserManager.FindByIdAsync(toBeUpdatedUser.Id);

                RedirectToAction("GetUserDetails");
            }

            ViewBag.Title = "Changes saved successfully";
            return PartialView("UserInfoPopUp");


        }

        [HttpPost]
        public ActionResult PostNewUser()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult UserEdit(string UserId)
        //{
        //    var model = _unitOfWork.Account.getUserById(UserId);//db.Users.Where(u => u.Id.Equals(UserId)).FirstOrDefault();
        //    return View(model);
        //}

        //public ActionResult SomeAjax(string term)
        //{
        //    var model = db.Roles.Select(r => new { r.Name }).ToList();
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}


        [HttpPost]
        public ActionResult PostRoles(RoleVM vm)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Roles.AddRole(new ApplicationRole { Name = vm.Name });
                _unitOfWork.Complete();


                var model = new RoleVM
                {
                    Roles = _unitOfWork.Roles.GetAll(),
                    Name = ""
                };

                return PartialView("_RolePartialTBodyDiv", model);
            }
            else
            {
                ModelState.AddModelError("", "could not save");
                return PartialView("_RolePartialTBodyDiv", ModelState);
            }
        }



        [HttpPost]
        public ActionResult PostAllowedDomain(AllowedDomainVM vm)
        {

            if (ModelState.IsValid)
            {

                _unitOfWork.allowedDomains.AddaDomainByName(vm.newDomainName);
                _unitOfWork.Complete();

                var model = new AllowedDomainRolesSingleVM
                {
                    newDomainName = vm.newDomainName,
                    AllRoles = _unitOfWork.Roles.GetAll().Select(r => (string)r.Name).ToList(),
                    Message = ""

                };

                return PartialView("_AllowedDomainRow", model);
            }
            else
            {
                ModelState.AddModelError("", "could not save");
                return PartialView("_AllowedDomainRow", ModelState);
            }
        }

        //Post: /Admin/PostDomainRoles
        //The body of the PostHttprequest should contain list of Roles and AllowedDomainName ID
        //The method will update Roles assigned to particular AllowedDomain
        //For example {allowedDomain: student.fh-kiel.com, DefaultRole: Student
        [HttpPost]
        public ActionResult PostDomainRoles(string DomainName, string RoleName, string option)
        {
            if (ModelState.IsValid)
            {
                switch (option)
                {
                    case "selected":
                        _unitOfWork.allowedDomains.AddaRoleToDomain(DomainName, RoleName);
                        _unitOfWork.Complete();
                        ViewBag.Message = "User Added to Role";
                        break;
                    case "deselected":
                        _unitOfWork.allowedDomains.RemovedRoleFromADomain(DomainName, RoleName);
                        _unitOfWork.Complete();
                        ViewBag.Message = "User Removed From Role";
                        break;
                    default:
                        ViewBag.Message = "No changes made";
                        break;
                }

                return PartialView("UserInfoPopUp");
            }
            ViewBag.Message = "somethign went wrong";
            return PartialView("UserInfoPopUp");
        }





        ////[HttpGet]
        ////public ActionResult GetRolesByDomain(int id)
        ////{

        ////    var result = db.AllowedDomains
        ////        .Where(d => d.DomainName.Contains("google"))
        ////        .Include(t => t.Roles)
        ////        .FirstOrDefault();

        ////    result.Roles = db.Roles.ToList();
        ////    db.SaveChanges();
        ////    string ret = null;
        ////    foreach (var item in db.Roles.ToList())
        ////    {
        ////        ret += item.Name;
        ////    }
        ////    return Content(ret);
        ////}




        [HttpGet]
        //Get : /Admin/DomainRoleDetails/1
        //This Method is responsiple to return One allowed Domain with list of default Roles assigned to it.
        // example: it could return { allowedDomain: Google.com, Roles: Admin, Supervisor}
        public ActionResult DomainRoleDetails(int Id)
        {
            //var result = db.AllowedDomains
            //    .Where(d => d.DomainName.Contains("google"))
            //    .Include(t => t.Roles)
            //    .FirstOrDefault();

            var model = new DomainRolesVM
            {
                AlloweDomain = _unitOfWork.Roles.getAllowedDomainByID(Id),
                AllRoles = _unitOfWork.Roles.GetAllApp()
            };
            return PartialView("_DomainModalPartial", model);
        }


        [HttpGet]
        public ActionResult EmailServerSettings()
        {

            //var fromPassword = System.Configuration.ConfigurationManager.AppSettings["mailPassword"];
            //var fromEmail = System.Configuration.ConfigurationManager.AppSettings["mailAccount"];

            //ViewBag.Host = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
            //ViewBag.Port = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["SMTPPort"]);
            //ViewBag.EnableSsl = true;
            //ViewBag.DeliveryMethod1 = System.Net.Mail.SmtpDeliveryMethod.Network;
            //ViewBag.UseDefaultCredentials = false;
            //ViewBag.Credentials = new System.Net.NetworkCredential(fromEmail, fromPassword);


            var model = new EmailServerSettings();
            return View("EmailSetting/EmailServerSettings", model);
        }

        [HttpPost]
        public ActionResult PostEmailServerSettings()
        {
            ViewBag.Message = "Saved sucessfully";
            return PartialView("UserInfoPopUp");
        }

        public ActionResult PostEmailContent(EmailContentVM model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EmailSetting.AddEmailContent(model);
                _unitOfWork.Complete();
                return PartialView("EmailSetting/_EmailContentPartial", model);
            }
            ViewBag.Message = "Something is not right";
            return PartialView("UserInfoPopUp");

        }

        [HttpPost]
        public ActionResult UpdateEmailContent(EmailContentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ToBeUpdated = new ToUserEmailContents()
                    {
                        EmailType = model.EmailType,
                        Subject = model.Subject,
                        Body = model.Body
                    };
                    _unitOfWork.Email.UpdateEmailContent(ToBeUpdated);
                    _unitOfWork.Complete();



                    ViewBag.Message = "Updated Successfully";
                    return PartialView("UserInfoPopUp");
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error while saving changes " + e.Message;
                return PartialView("UserInfoPopUp");
            }
            ViewBag.Message = "Something is not right";
            return PartialView("UserInfoPopUp");

        }



        [HttpGet]
        public ActionResult Departments()
        {
            var model = _unitOfWork.Departments.GetAll();

            var model2 = model.Select(
                d => new DepartmentVM
                {
                    RecID = d.RecID,
                    Name = d.Name,
                    Description = d.Description,
                    AllDegreeType = _unitOfWork.Departments.GetAllDegreeTypes(),
                    DegreePrograms = d.DegreePrograms.Select(f => new DegreeProgramVM
                    {
                        RecID = f.RecID,
                        Name = f.Name,
                        Description = f.Description,
                        Specializations = f.Specializations.Select(s => new SpecializationVM
                        {
                            Name = s.Name,
                            Description = s.Description
                        }).ToList()
                    }).ToList()
                }).ToList();


            return View("Degrees/Degrees", model2);
        }

        [HttpPost]
        public ActionResult PostADepartment(string Name, string Description)
        {
            Department result = null;
            if (ModelState.IsValid)
            {
                var model = new Department
                {

                    Name = Name,
                    Description = Description,
                    CreationDate = GetCurrentDate()

                };
                result = _unitOfWork.Departments.AddADepartment(model);
                _unitOfWork.Complete();

            }

            var m = new DepartmentVM
            {
                RecID = result.RecID,
                Name = Name,
                Description = Description
            };



            return PartialView("Degrees/_Department", m);
        }

        public ActionResult PostADegreeProgram(DegreeProgramVM vm, Guid DepId)
        {
            if (ModelState.IsValid)
            {
                var _DegreeType = _unitOfWork.Departments.GetADegreeTypeByName(vm.DegreeType);
                var model = new DegreeProgram
                {

                    Name = vm.Name,
                    Description = vm.Description,
                    CreationDate = GetCurrentDate(),
                    DegreeType = _DegreeType

                };

                _unitOfWork.Departments.AddADegreePorgram(model, DepId);
                _unitOfWork.Complete();

            }
            //Get a RecID of a DegreeProgram that is 
            vm.RecID = _unitOfWork.Departments.GetADgreeProgram(DepId, vm.Name).RecID;
            ViewBag.departmentId = DepId;


            //TODO: VM requires RecID

            return PartialView("Degrees/_DegreeProgram", vm);

        }

        public ActionResult PostASpecialization(SpecializationVM vm, Guid DegreeProgramID)
        {
            if (ModelState.IsValid)
            {
                var model = new Specialization
                {

                    Name = vm.Name,
                    Description = vm.Description,
                    CreationDate = GetCurrentDate()

                };
                _unitOfWork.Departments.AddASpecialization(model, DegreeProgramID);
                _unitOfWork.Complete();

            }
            return PartialView("Degrees/_SpecializationPartial", vm);
        }

        [HttpPost]
        public ActionResult deleteRoles(string guid)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Roles.deleteRoles(guid);
                _unitOfWork.Complete();
                var model = new RoleVM
                {
                    Roles = _unitOfWork.Roles.GetAll(),
                    Name = ""
                };

                return PartialView("_RolePartialTBodyDiv", model);
            }
            else
            {
                ModelState.AddModelError("", "could not save");
                return PartialView("_RolePartialTBodyDiv", ModelState);
            }
        }


        public JsonResult TestMe()
        {
            var db = new ApplicationDbContext();

            //var _EmailSetting = from s in db.SystemSettings
            //                    group s by s.ConfigurationFor into g
            //                    select new SystemSettings
            //                    {
            //                        Key = (from x in g orderby x.Version descending select x.Key).FirstOrDefault(),
            //                        Value = g.Key

            //                    };
            //var _EmailSetting = db.SystemSettings.Where(w => w.ConfigurationFor.Equals("Email")).
            //    GroupBy(c => c.Version).
            //    Select(x => x.OrderByDescending(c => c.Version)).ToList();.Max(w => w.Version)
            
                
            return Json(_unitOfWork.SystemSettings.GetCurrentConfigurationFor("NoMan"), JsonRequestBehavior.AllowGet);
    }
    public static DateTime GetCurrentDate()
    {
        var now = DateTime.Now;
        var date = new DateTime(now.Year, now.Month, now.Day,
                                now.Hour, now.Minute, now.Second);
        return date;
    }
}
}
