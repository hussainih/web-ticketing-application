using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Ticketing.Entity.TicketModel;

namespace Ticketing.Data.ViewModels
{


    //Fachbereich
    public class DepartmentVM
    {
        [Key]
        
        public Guid RecID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<DegreeType> AllDegreeType { get; set; }





        //Navigation
        public virtual ICollection<DegreeProgramVM> DegreePrograms { get; set; }
    }

    //Studiengänge
    public class DegreeProgramVM
    {
        [Key]
       
        public Guid RecID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string DegreeType { get; set; }

        //Navigation
        public virtual DepartmentVM Department { get; set; }
        public virtual ICollection<SpecializationVM> Specializations { get; set; }
        


    }

    //Schwerpunk
    public class SpecializationVM
    {
        [Key]
       
        public Guid RecID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }

        //Navigation
        public virtual DegreeProgramVM DegreePrograms { get; set; }


    }
}