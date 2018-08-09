using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Ticketing.Entity.TicketModel;
using Ticketing.Identity;
using Ticketing.TicketModel;


namespace Ticketing.Data.ViewModels
{
    public class ProposalVM
    {
        public ProposalVM()
        {
            AllDegreeTypes = new List<DegreeType>();
            ExternalSupervisor = new ExternalSupervisorVM();
            
        }
        [Key]
        public Guid RecId { get; set; }
        [Required(ErrorMessage ="{0} is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }


        //Navigations
        
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "New password")]
        [Display(Name="Proposal Type")]
        public KeyValue ProposalType { get; set; }

        [Display(Name="Degree Type")]
        [Required]
        public KeyValue DegreeType { get; set; }
        
        [Display(Name = "Degree Program")]
        [Required]
        public KeyValue DegreeProgram { get; set; }

        [Display(Name = "Specialization")]
        [Required]
        public KeyValue Specilizations { get; set; }

        [Display(Name = "First Supervisor")]
        [Required]
        public KeyValue FirstSupervisor { get; set; }

        [Display(Name = "Second Supervisor")]
        public KeyValue SecondSupervisor { get; set; }

        
        [Display(Name = "Proposal")]
        [Required]
        public ProposalContent ProposalContent { get; set; } //To let have many version of one Proposal content due to Modifications
       
       
        
        
        public virtual ExternalSupervisorVM ExternalSupervisor { get; set; }
        
        public virtual ICollection<DegreeType> AllDegreeTypes {get; set;}
        
        public virtual ICollection<ProposalType> AllProposalTypes { get; set; }

      

    }
}