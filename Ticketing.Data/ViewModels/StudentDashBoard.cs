using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticketing.TicketModel;

namespace Ticketing.Data.ViewModels
{
    public class StudentDashBoard
    {
        public ICollection<Proposal> Proposals { get; set; }
        
    }
}