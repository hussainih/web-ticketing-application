using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Entity.Resources;
using Ticketing.Identity;

namespace Ticketing.TicketModel
{
    // The contents of AllowedDomain Model include all domains that a User of a system is allowed to loged in
    // The system admin should first setup Roles in AspNetRoles table and define atleast one role in this model.
    public class AllowedDomains
    {
        public AllowedDomains()
        {
            this.Roles = new HashSet<ApplicationRole>();
        }
        [Key]
        public int RecID { get; set; }

        [Required]
        [Display(Name = "DomainName", ResourceType = typeof(Resource))]
        public string DomainName { get; set; }

        [Display(Name = "DefaultRoles", ResourceType = typeof(Resource))]
        public virtual ICollection<ApplicationRole> Roles { get; set; }
    }
}
