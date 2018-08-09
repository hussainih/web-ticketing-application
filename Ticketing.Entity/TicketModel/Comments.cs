using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticketing.TicketModel
{
    public class Comments
    {
        [Key]
        [Required]
        public int RecID { get; set; }

        public virtual Ticket Ticket { get; set; }

        

        [Required]
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual Comments RepliedTo { get; set; }

        public string CommentsFor { get; set; }
        

    }
}