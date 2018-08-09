using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ticketing.Data.ViewModels;
using Ticketing.Entity.TicketModel;
using Ticketing.Identity;
using Ticketing.TicketModel;

namespace Ticketing.Data.Repository
{
    public interface IProposalRepository
    {

        string getProposalStatus(string Id);
        Proposal SubmitProposal(Proposal model);
        ICollection<Proposal> GetByUser(string userid);
        ICollection<ProposalType> GetAllProposalTypes();
        ProposalType GetProposalTypeById(Guid guid);
        ICollection<Proposal> GetBySuperVisor(string id);
        ICollection<Proposal> GetProposalsById(Guid guid);
    }
    public class ProposalRepository : IProposalRepository
    {
        private readonly ApplicationDbContext _context;

        
        public ProposalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<ProposalType> GetAllProposalTypes()
        {
            return _context.ProposalTypes.ToList();
        }

        public ICollection<Proposal> GetBySuperVisor(string id)
        {
            return _context.Proposal.Where(x => x.FirstSupervisor.Id.Equals(id) || x.SecondSupervisor.Id.Equals(id)).ToList();
        }

        public ICollection<Proposal> GetByUser(string userid)
        {
            return _context.Proposal.Include(x => x.ProposalStatus).Where(x => x.CreatedBy.Id.Equals(userid)).ToList();
        }

        public ProposalType GetProposalTypeById(Guid guid)
        {
            return _context.ProposalTypes.Where(x => x.RecID.Equals(guid)).FirstOrDefault();
        }

        public string getProposalStatus(string Id)
        {
            //TODO: return valid status
            return "Nothing";
        }

        public Proposal SubmitProposal(Proposal model)
        {

            return _context.Proposal.Add(model);

        }

        public ICollection<Proposal> GetProposalsById(Guid guid)
        {
            return _context.Proposal.Include(x => x.ProposalContent).Where(x => x.RecId.Equals(guid)).ToList();
        }
    }
}