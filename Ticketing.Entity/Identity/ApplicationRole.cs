using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.TicketModel;

namespace Ticketing.Identity
{
    public class ApplicationRole : IdentityRole
    {

        public ApplicationRole() : base()
        {
            AllowedDomains = new HashSet<AllowedDomains>();
        }

        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }
        public virtual ICollection<AllowedDomains> AllowedDomains { get; set; }
    }
}
