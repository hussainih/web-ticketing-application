using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Entity.TicketModel
{
    //Fachbereich
   public class Department
    {
        public Department()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        
       


        //Navigation
        public virtual ICollection<DegreeProgram> DegreePrograms { get; set; }
    }

    //Studiengänge
    public class DegreeProgram
    {
        public DegreeProgram()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        //Navigation
        public virtual DegreeType DegreeType {get; set;}
        public virtual Department Department { get; set; }
        public virtual ICollection<Specialization> Specializations { get; set; }


    }

    //Schwerpunk
    public class Specialization
    {
        public Specialization()
        {
            CreationDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }

        //Navigation
        public virtual DegreeProgram DegreePrograms { get; set; }
        

    }

    public class DegreeType
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Recid { get; set; }
        public string Name { get; set; }
    }
}
