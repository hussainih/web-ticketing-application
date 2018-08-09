using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using Ticketing.Data.Persistence;
using Ticketing.Identity;
using Ticketing.Entity.TicketModel;

namespace Ticketing.Services
{
    public class EmailService { 

        public static async Task SendVerificationEmail(IdentityMessage message)
        {
            //TODO: get the email server settings from Database and if does not exsit get it from web.config
            ICollection<SystemSettings> _EmailSetting;
            try
            {

                var db = new ApplicationDbContext();

                _EmailSetting = db.SystemSettings.Where(w => w.ConfigurationFor.Equals("Email")).ToList();

                _EmailSetting = _EmailSetting.Where(w => w.ConfigurationFor.Equals("Email") && w.Version.Equals(_EmailSetting.Max(x => x.Version))).ToList();

            }
            catch (Exception e)
            {
                throw e;
            }


            if(_EmailSetting != null)
            {

            }
            else
            {

            }

            var fromEmail = new MailAddress(ConfigurationManager.AppSettings["mailAccount"], "The Ticketing Robot");
            var toEmail = new MailAddress(message.Destination);
            var fromPassword = ConfigurationManager.AppSettings["mailPassword"];

            var Host1 = ConfigurationManager.AppSettings["SMTPHost"];
            var Port1 = Int32.Parse(ConfigurationManager.AppSettings["SMTPPort"]);
            //var EnableSsl1 = true;
            //var DeliveryMethod1 = SmtpDeliveryMethod.Network;
            //var UseDefaultCredentials1 = false;
            var Credentials1 = new NetworkCredential(fromEmail.Address, fromPassword);



            var smtp = new SmtpClient
            {
                Host = ConfigurationManager.AppSettings["SMTPHost"],
                Port = Int32.Parse(ConfigurationManager.AppSettings["SMTPPort"]),
                EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromPassword)
            };
            // var fromEmail = new MailAddress(ConfigurationManager.AppSettings["mailAccount"], "The Ticketing Robot");
            // var toEmail = new MailAddress(message.Destination);
            // var fromPassword = ConfigurationManager.AppSettings["mailPassword"];

            //var Host1 = ConfigurationManager.AppSettings["SMTPHost"];
            // var Port1 = Int32.Parse(ConfigurationManager.AppSettings["SMTPPort"]);
            // //var EnableSsl1 = true;
            // //var DeliveryMethod1 = SmtpDeliveryMethod.Network;
            // //var UseDefaultCredentials1 = false;
            // var Credentials1 = new NetworkCredential(fromEmail.Address, fromPassword);



            // var smtp = new SmtpClient
            // {
            //     Host = ConfigurationManager.AppSettings["SMTPHost"],
            //     Port = Int32.Parse(ConfigurationManager.AppSettings["SMTPPort"]),
            //     EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]),
            //     DeliveryMethod = SmtpDeliveryMethod.Network,
            //     UseDefaultCredentials = false,
            //     Credentials = new NetworkCredential(fromEmail.Address, fromPassword)
            // };

            using (var myMessage = new MailMessage(fromEmail, toEmail)
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            })

              await smtp.SendMailAsync(myMessage);
        }
        
    }
}