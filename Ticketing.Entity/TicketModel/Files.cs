using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticketing.TicketModel
{
    public class Files
    {
        [Key]
        [Required]
        public int RecID { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public string File { get; set; }

    }
}