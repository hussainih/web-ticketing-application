using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticketing.Data.TicketModel.ViewModels;
using Ticketing.Entity.TicketModel;
using Ticketing.Identity;

namespace Ticketing.Data.Repository
{
    public interface IEmailRepository
    {
        ICollection<ToUserEmailContents> GetAllEmailContents();
        ToUserEmailContents GetEmailContentByPurposeName(string EmailPurpose);
        ToUserEmailContents UpdateEmailContent(ToUserEmailContents model);
    }

    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationDbContext _context;

        public EmailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<ToUserEmailContents> GetAllEmailContents()
        {
            return _context.ToUserEmailContents.ToList();
        }
        public ToUserEmailContents GetEmailContentByPurposeName(string EmailPurpose)
        {
            return _context.ToUserEmailContents.Where(x => x.EmailType.Equals(EmailPurpose)).FirstOrDefault();
        }

        public ToUserEmailContents UpdateEmailContent(ToUserEmailContents model)
        {
            var ToBeUpdated = _context.ToUserEmailContents.Where(x => x.EmailType.Equals(model.EmailType)).FirstOrDefault();
            ToBeUpdated.Subject = model.Subject;
            ToBeUpdated.Body = model.Body;
            return ToBeUpdated;
        }

        
    }
}