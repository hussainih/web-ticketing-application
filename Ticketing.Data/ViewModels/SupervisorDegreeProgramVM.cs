using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Ticketing.Entity.TicketModel;
using Ticketing.Identity;

namespace Ticketing.Data.ViewModels
{
    public class SupervisorDegreeProgramVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecID { get; set; }

        //Navigation
        public virtual ApplicationUser Supervisor { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}