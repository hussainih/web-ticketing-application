using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Entity.TicketModel
{

    //holds information about the type of Degree that needs to be submitted
    public class ProposalType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecID { get; set; }
        public string Name { get; set; } 
    }
}
