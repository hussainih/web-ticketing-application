using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Entity.TicketModel
{
    public class ToUserEmailContents
    {
        [Key]
        
        public string EmailType { get; set; }
        public string Subject { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}
