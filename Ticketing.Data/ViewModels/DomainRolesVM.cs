using System;
using System.Collections.Generic;
using Ticketing.Identity;
using Ticketing.TicketModel;

namespace Ticketing.Data.TicketModel.ViewModels
{
    //this model provides information on how many default roles are assigned to an Allowed domain
    //it should also return list of all the available roles, so if you user wants to change default roles
    // for a domain they could do so.
 public class DomainRolesVM
    {
        //public DomainRolesVM()
        //{
        //    AllRoles = new ApplicationDbContext().Roles.ToList();
        //}
        public AllowedDomains AlloweDomain { get; set; }
        public ICollection<ApplicationRole> AllRoles { get; set; }
       

    }

    public class DomainRoles
    {
        public string Role { get; set; }
        public Boolean status { get; set; }
    }
}
