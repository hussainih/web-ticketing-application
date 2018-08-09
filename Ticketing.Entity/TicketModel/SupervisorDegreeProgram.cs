﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Identity;

namespace Ticketing.Entity.TicketModel
{
    public class SupervisorDegreeProgram
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecID { get; set; }
        
        //Navigation
        public virtual ApplicationUser Supervisor { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}
