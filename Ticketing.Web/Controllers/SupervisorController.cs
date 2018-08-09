using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketing.Data.Persistence;
using Ticketing.Data.ViewModels;
using Ticketing.Entity.TicketModel;

namespace Ticketing.Controllers
{
    public class SupervisorController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationUserManager UserManager;
        public SupervisorController(IUnitOfWork unitOfWork, ApplicationUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            UserManager = userManager;
        }


        // GET: Supervisor
        public ActionResult Index()
        {
            var CurrentUser = UserManager.FindByName(User.Identity.Name);
            var Proposals = _unitOfWork.Proposals.GetBySuperVisor(CurrentUser.Id).ToList();
            
                var model = new SupervisorDashBoard()
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

        [HttpPost]
        public ActionResult AddSpecializatinToSupervisor(Guid Specialization, string UserID)
        {
            if (ModelState.IsValid)
            {
                var model = _unitOfWork.Departments.AddSpecializationForSupervisor(Specialization, UserID);
                if (model.RecID == null)
                {
                    ViewBag.Message = "Could Not save";
                }
                else
                {
                    ViewBag.Message = "Saved Successfully";
                }
                return View("UserInfoPopUp");
            }
            return View("UserInfoPopUp");

        }


        [HttpGet]
        public JsonResult GetSuperVisorSpecializationData(string UserRecID)
        {
            var model = _unitOfWork.Departments.GetAll();
            ICollection<SupervisorDegreeProgram> CheckedValues = _unitOfWork.Departments.getSuperVisorSpecialzation(UserRecID);

            var root = new JsTree3Node()
            {
                id = "Dsdfkjasdlfkjsasldkfjsdlfkj",
                text = "Departments",
                state = new State(true, false, false)
            };

            var DeppartmentNodes = new List<JsTree3Node>();

            foreach (var department in model)
            {
                var DNode = JsTree3Node.NewNode(department.RecID.ToString());
                DNode.state = new State(false, false, false);
                DNode.text = department.Name;
                foreach (var degreeProgram in department.DegreePrograms)
                {
                    //create degreeProgramNode
                    var DPNode = JsTree3Node.NewNode(degreeProgram.RecID.ToString());
                    DPNode.state = new State(false, false, false);
                    DPNode.text = degreeProgram.Name;
                    foreach (var specialization in degreeProgram.Specializations)
                    {
                        var IsChecked = false;
                        foreach(var item in CheckedValues)
                        {
                            if (item.Specialization.RecID.Equals(specialization.RecID))
                            {
                                IsChecked = true;
                            }
                        }
                        var SNode = JsTree3Node.NewNode(specialization.RecID.ToString());
                        SNode.state = new State(false, false, IsChecked);

                        SNode.text = specialization.Name;
                        DPNode.children.Add(SNode);
                    }
                    //Add degreeProram in DNode
                    DNode.children.Add(DPNode);
                }
                DeppartmentNodes.Add(DNode);
            }
            //End of foreach
            root.children = DeppartmentNodes;

            return Json(root, JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        public ActionResult PostSuperVisorSpecializationData(string SuperVisorRecID, ICollection<string> Specializations)
        {
            //var existing = _unitOfWork.Departments.GetSpecializationsByUserRecID(UserRecID);
            if (ModelState.IsValid)
            {
                var model = _unitOfWork.Departments.UpdateSpcializationsByUserRecID(SuperVisorRecID, Specializations);
                _unitOfWork.Complete();
                ViewBag.Message = "Saved Successfully";

                return PartialView("UserInfoPopUp");
            }
            return PartialView("UserInfoPopUp");

        }

        [HttpGet]
        public ActionResult Setting()
        {
            var model = new SupervisorDegreeProgramVM()
            {
                Supervisor = UserManager.FindByName(User.Identity.Name)
            };

            return View(model);
        }
    }
}
