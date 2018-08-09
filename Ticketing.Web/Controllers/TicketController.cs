using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketing.Data.Persistence;
using Ticketing.Data.ViewModels;
using Ticketing.Identity;
using Ticketing.TicketModel;

namespace Ticketing.Controllers
{
    public class TicketController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationUserManager UserManager;
        private readonly ApplicationDbContext _context;
        public TicketController(IUnitOfWork unitOfWork, ApplicationUserManager userManager, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            UserManager = userManager;
            _context = context;
        }

        // GET: Ticket
        public ActionResult Index(string Id)
        {

            var model = new Proposal();
            model = _context.Proposal.Where(x => x.RecId.Equals(new Guid(Id))).Include(t => t.Ticket).FirstOrDefault();

            return View(model);
        }

        public ActionResult Proposal(string ProposalId)
        {
            var model = _context.Proposal.Where(p => p.RecId.Equals(new Guid(ProposalId))).Include(x => x.ProposalContent).FirstOrDefault();
            return PartialView(model);

        }

        [HttpPost] 
        public ActionResult UpdateProposalContent(string ProposalId, ProposalContent Content)
        {
            var model = _context.Proposal.Where(x => x.RecId.Equals(new Guid(ProposalId))).Include(c => c.ProposalContent).FirstOrDefault();
            model.ProposalContent.Content = Content.Content;
            return PartialView("_ProposalContent", model);
        }
        public ActionResult Documents()
        {
            return PartialView();
        }

        

        public ActionResult Discussions()
        {
            return PartialView();

        }
        
        public ActionResult Log()
        {
            return PartialView();
        }

        public ActionResult Reports()
        {
            return PartialView();
        }
    }
}