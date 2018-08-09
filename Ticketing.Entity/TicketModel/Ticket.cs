using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ticketing.TicketModel
{
    public class Ticket

    {
        public Ticket()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecID { get; set; }
        public string Title { get; set; }
        public string TicketType { get; set; } //for the moment useless
        public DateTime CreationDate { get; set; }

        //Navigations
        public virtual ICollection<Contributor> Contributors { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<TicketStatus> Status { get; set; }
     


    }
   
}