using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.TicketModel
{
    public class ProposalStatus
    {
        public ProposalStatus()
        {
            Version = DateTime.UtcNow.ToString();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecId { set; get; }

        public string Status { get; set; }
        public string Description { get; set; }

        public string Version { get; set; }

        //Navigation
        public virtual Proposal Proposal {get; set;}
        
    }
}