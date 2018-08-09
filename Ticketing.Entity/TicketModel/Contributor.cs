using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Ticketing.Identity;

namespace Ticketing.TicketModel
{
    public class Contributor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecID { get; set; }
        public string Status { get; set; }
        
        //Navigations
        public virtual ApplicationRole RoleInTicket { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Ticket Ticket { get; set; }
        
  
        
    }
}