using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Ticketing.Entity.TicketModel;
using Ticketing.TicketModel;

namespace Ticketing.Data.ViewModels
{
    public class TicketProposalsVM
    {
        public TicketProposalsVM()
        {
        }
        [Key]
        public Guid RecId { get; set; }
        
        
        
        
    }


}
