using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Ticketing.Entity.TicketModel;
using Ticketing.Identity;

namespace Ticketing.TicketModel
{
    public class Proposal
    {
        public Proposal()
        {
            CreationDate = DateTime.Now;
            ProposalStatus = new List<ProposalStatus>();
            
        }


        [Key]
        [ForeignKey("Ticket")]
        public Guid RecId { get; set; }

        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }

        //Navigations
        
     
        public virtual ProposalContent ProposalContent { get; set; } //To let have many version of one Proposal content due to Modifications
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ICollection<ProposalStatus> ProposalStatus { get; set; } //Status can be changed thre 1..*
        public virtual DegreeType DegreeType { get; set; }
        public virtual DegreeProgram DegreeProgram { get; set; }
        public virtual Specialization Specializations { get; set; }
        public virtual ApplicationUser FirstSupervisor { get; set; } //All Users involved in the Ticket, though with different Roles
        public virtual ApplicationUser SecondSupervisor { get; set; }
        public virtual ProposalType ProposalType { get; set; }
        public virtual Ticket Ticket { get; set; }
      
        public static DateTime GetCurrentDate()
        {
            var now = DateTime.Now;
            var date = new DateTime(now.Year, now.Month, now.Day,
                                    now.Hour, now.Minute, now.Second);
            return date;
        }
    }
   
}