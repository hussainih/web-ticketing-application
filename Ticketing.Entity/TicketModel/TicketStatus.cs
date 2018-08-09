using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticketing.TicketModel
{
    public class TicketStatus
    {
        public TicketStatus()
        {
            Version = DateTime.UtcNow;
        }
        [Key]
        public int recordID { get; set; }

        [DisplayName("Ticket Status")]
        public string Status { get; set; }
        public DateTime Version { get; set; }
        //Navigation
        public virtual Ticket Ticket {get; set;}
    }
}