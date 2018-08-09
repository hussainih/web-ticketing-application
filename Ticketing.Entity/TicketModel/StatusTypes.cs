using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Entity.TicketModel
{
    public class StatusTypes
    {
        
        [Key]
        public int RecID { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
