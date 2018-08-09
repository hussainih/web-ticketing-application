using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticketing.Data.TicketModel.ViewModels
{
    public class EmailContentVM
    {
        [Key]
        public string EmailType { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}