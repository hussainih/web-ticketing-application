using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ticketing.Data.Persistence;

using Ticketing.Data.ViewModels;
using Ticketing.Identity;
using Ticketing.TicketModel;

namespace Ticketing.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationUserManager UserManager;
        private readonly ApplicationDbContext db;
        public StudentController(IUnitOfWork unitOfWork, ApplicationUserManager userManager, ApplicationDbContext context)
        {
            db = context;
            _unitOfWork = unitOfWork;
            UserManager = userManager;
        }


        [HttpGet]
        public ActionResult Index()
        {

            var CurrentUser = UserManager.FindByName(User.Identity.Name);
            var Proposals = _unitOfWork.Proposals.GetByUser(CurrentUser.Id).ToList();
            if (Proposals != null)
            {
                var model = new StudentDashBoardVM()
                {

                    Proposals = Proposals.Select(x => new ProposalDS()
                    {
                        Name = x.Name,
                        RecId = x.RecId,
                        Status = x.ProposalStatus.OrderBy(s => s.Version).FirstOrDefault().Status,
                        StudyProgram = x.DegreeProgram.Name,
                        SubmissionDate = x.CreationDate

                    }).ToList()
                };
                return View(model);
            }


            var m = new StudentDashBoardVM();

            return View(m);




        }





        [HttpGet]
        public ActionResult StudentProposal()
        {
            var model = new ProposalVM
            {
                AllProposalTypes = _unitOfWork.Proposals.GetAllProposalTypes(),
                AllDegreeTypes = _unitOfWork.Departments.GetAllDegreeTypes()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> StudentProposal(ProposalPostVM vm)
        {
            var ReturnMoodel = new ProposalVM()
            {
                AllProposalTypes = _unitOfWork.Proposals.GetAllProposalTypes(),
                AllDegreeTypes = _unitOfWork.Departments.GetAllDegreeTypes()
            };
            if (!vm.ProposalType.Value.Equals("Thesis"))
            {
                ModelState["FirstName"].Errors.Clear();
                ModelState["LastName"].Errors.Clear();
                ModelState["Email"].Errors.Clear();
                ModelState["Company"].Errors.Clear();


            }
            if (ModelState.IsValid)
            {
                //////////Create List of Contirbutors in the ticket
                var _Contributors = new List<Contributor>();
                var student = UserManager.FindByName(User.Identity.Name);
                var StudentRoleInTicket = db.Roles.Where(x => x.Name.Equals("Student")).FirstOrDefault();

                var FirstSupervisor = UserManager.FindById(vm.FirstSupervisor.Key);
                var FirstSuperVisorRole = db.Roles.Where(x => x.Name.Equals("Supervisor")).FirstOrDefault();

                _Contributors.Add(new Contributor() { User = student, RoleInTicket = StudentRoleInTicket, Status = "Approved" });
                _Contributors.Add(new Contributor() { User = FirstSupervisor, RoleInTicket = FirstSuperVisorRole, Status = "Approved" });

                ApplicationUser SecondSupervisor;
                ApplicationRole SecondSuperVisorRole;

                //If The Proposal is for Thesis than Second Supervisor Should be Assigned.
                if (vm.ProposalType.Value.Equals("Thesis"))
                {
                    //If Supervisor is not external and from university than assign it directly
                    if (!vm.SecondSupervisor.Key.Equals("ExternalSupervisor"))
                    {
                        SecondSupervisor = UserManager.FindById(vm.SecondSupervisor.Key);
                        SecondSuperVisorRole = db.Roles.Where(x => x.Name.Equals("SecondSupervisor")).FirstOrDefault();

                        _Contributors.Add(new Contributor() { User = SecondSupervisor, RoleInTicket = SecondSuperVisorRole, Status = "Approved" });
                    }
                    //If Supervisor is not from University and also not already registered
                    else
                    {
                        var externalUser = new ApplicationUser
                        {
                            UserName = vm.ExternalSupervisor.Email,
                            Email = vm.ExternalSupervisor.Email,
                            FirstName = vm.ExternalSupervisor.LastName,
                            LastName = vm.ExternalSupervisor.LastName,
                            IsExternal = true
                        };
                        var result =  UserManager.Create(externalUser);
                        
                        //Error normally occors if supervisory is already there
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", "The Second Supervisor you are trying to add already exist select it from Second supervisor list" + result.Errors);
                            return View(ReturnMoodel);
                        }

                        SecondSupervisor = UserManager.FindByEmail(vm.ExternalSupervisor.Email);
                        SecondSuperVisorRole = db.Roles.Where(x => x.Name.Equals("SecondSupervisor")).FirstOrDefault();
                        _Contributors.Add(new Contributor() { User = SecondSupervisor, RoleInTicket = SecondSuperVisorRole, Status = "Approval Pending" });
                    }

                }
                //Contirbutors are created now


                var NewTicket = new Ticket()
                {
                    Title = vm.Name,
                    TicketType = "Degree",
                    Status = new List<TicketStatus>() { new TicketStatus() { Status = "Proposal Submitted" } },
                    Contributors = _Contributors

                };





                // NewTicket.Contributors.Add()

                var NewProposal = new Proposal()
                {
                    Name = vm.Name,
                    FirstSupervisor = UserManager.FindById(vm.FirstSupervisor.Key),
                    SecondSupervisor = vm.SecondSupervisor.Key == null ? null : UserManager.FindById(vm.SecondSupervisor.Key),
                    ProposalContent = new ProposalContent() { Content = vm.ProposalContent.Content },
                    CreatedBy = UserManager.FindByName(User.Identity.Name),
                    Ticket = NewTicket

                };
                //Rest of the virtual links are assigned here to avoid creation of new records
                NewProposal.ProposalType = _unitOfWork.Proposals.GetProposalTypeById(new Guid(vm.ProposalType.Key));
                NewProposal.DegreeType = _unitOfWork.Departments.GetDegreeTypeById(new Guid(vm.DegreeType.Key));
                NewProposal.DegreeProgram = _unitOfWork.Departments.GetDegreeProgramByID(new Guid(vm.DegreeProgram.Key));
                NewProposal.Specializations = _unitOfWork.Departments.GetSpecializationById(new Guid(vm.Specilizations.Key));
                NewProposal.ProposalStatus.Add(new ProposalStatus() { Status = "Proposal Submitted" });
                NewProposal.Ticket = NewTicket;

                db.Ticket.Add(NewTicket);
                db.Proposal.Add(NewProposal);
                db.SaveChanges();
                // //var result = _unitOfWork.Proposals.SubmitProposal(ToBeAdded);
                // //_unitOfWork.Complete();
                return RedirectToAction("Index");
                //ViewBag.Message = "Models were Correct";
                //return PartialView("UserInfoPopUp");
            }
            else
            {
                
                return View(ReturnMoodel);
            }

        


        //ViewBag.Message = "Your Proposal Submitted Successfully";
        //return RedirectToAction("UserInfoPopUp");
    }

    [HttpGet]
    public ActionResult GetDegreePrograms(KeyValue DegreeType)
    {
        var DegreePrograms = _unitOfWork.Departments.GetAllDegreeProgramsByID(DegreeType.Key);

        var result = DegreePrograms.Select(x => new KeyValue
        {
            Key = x.RecID.ToString(),
            Value = x.Name
        });
        return Json(result, JsonRequestBehavior.AllowGet);
    }

    [HttpGet]
    public ActionResult GetSpcializations(KeyValue DegreeProgram)
    {
        var Specializations = _unitOfWork.Departments.GetSpcializationByDegreeProgramID(DegreeProgram.Key);
        var result = Specializations.Select(x => new KeyValue
        {
            Key = x.RecID.ToString(),
            Value = x.Name
        });
        return Json(result, JsonRequestBehavior.AllowGet);
    }

    //[HttpGet]
    //public ActionResult GetSupervisorsBySpecializations(ICollection<Guid> SupervisorRecID, Boolean IsAll)
    //{
    //    var Supervisors = _unitOfWork.

    //}

    [HttpGet]
    public ActionResult GetSuggestedSupervisors(string Specialization)
    {
        var result = _unitOfWork.Departments.GetSuperVisorBySpecialization(Specialization);
        var ReturnVlues = result.Select(x => new KeyValue()
        {
            Key = x.Id,
            Value = x.FirstName + " " + x.LastName
        });

        return Json(ReturnVlues, JsonRequestBehavior.AllowGet);
    }


    [HttpGet]
    public ActionResult GetAllSupervisors()
    {
        var ReturnVlues = _unitOfWork.Departments.GetAllSupervisors().Select(x => new KeyValue()
        {
            Key = x.Id,
            Value = x.FirstName + " " + x.LastName
        });

        return Json(ReturnVlues, JsonRequestBehavior.AllowGet);

    }



    [HttpGet]
    public string Testing()
    {
        return "sucess";
    }
}
}
