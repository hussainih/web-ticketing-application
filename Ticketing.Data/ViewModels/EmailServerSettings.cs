using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Ticketing.Entity.TicketModel;
using Ticketing.Identity;

namespace Ticketing.Data.TicketModel.ViewModels
{
    public class EmailServerSettings
    {
        
        public EmailServerSettings()
        {
           
            Password = System.Configuration.ConfigurationManager.AppSettings["mailPassword"];
            FromEmail = System.Configuration.ConfigurationManager.AppSettings["mailAccount"];

            Host = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
            Port = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["SMTPPort"]);
            EnableSsl = true;
            DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            UseDefaultCredentials = false;
            using (var context = new ApplicationDbContext())
            {
                ToUserEmailContents = context.ToUserEmailContents.ToList();

            }
            //ViewBag.Credentials = new System.Net.NetworkCredential(fromEmail, fromPassword);
        }

        public string Password { get; set; }
        [Key]
        public string FromEmail { get; set; }
        public string Host { get; set; }
        public Int32 Port { get; set; }
        public Boolean EnableSsl { get; set; }
        public System.Net.Mail.SmtpDeliveryMethod DeliveryMethod { get; set; }
        public Boolean UseDefaultCredentials { get; set; }

        public ICollection<ToUserEmailContents> ToUserEmailContents { get; set; }
        
    }

    
}