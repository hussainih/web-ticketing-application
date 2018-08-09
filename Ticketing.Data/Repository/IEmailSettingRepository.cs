using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticketing.Data.TicketModel.ViewModels;
using Ticketing.Entity.TicketModel;
using Ticketing.Identity;

namespace Ticketing.Data.Repository
{
    public interface IEmailSettingRepository
    {
        void AddEmailContent(EmailContentVM settings);
    }
    public class EmailSettingRepository : IEmailSettingRepository
    {
        private readonly ApplicationDbContext _context;

        public EmailSettingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddEmailContent(EmailContentVM settings)
        {
            var model = new ToUserEmailContents
            {
                EmailType = settings.EmailType,
                Body = settings.Body,
                Subject = settings.Subject

            };
            _context.ToUserEmailContents.Add(model);
        }
    }
}