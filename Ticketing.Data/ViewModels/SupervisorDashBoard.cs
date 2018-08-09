using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticketing.Data.ViewModels
{
   

    public class SupervisorDashBoard
    {
        public ICollection<ProposalDS> Proposals { get; set; }

        public string Test { get; set; }
    }

    //Proposal view model for dashboard
   

}