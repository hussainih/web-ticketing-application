using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Ticketing.Data.ViewModels
{
    public class StudentDashBoardVM
    {
        public ICollection<ProposalDS> Proposals { get; set; }

        public string Test { get; set; }
    }
    
    //Proposal view model for dashboard
    public class ProposalDS
    {
        public Guid RecId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string StudyProgram { get; set; }
    }

    public class Notifications
    {

    }
}