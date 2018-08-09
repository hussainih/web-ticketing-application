using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ticketing.TicketModel;

namespace Ticketing.Data.TicketModel.ViewModels
{
    public class AllowedDomainVM
    {
        public IEnumerable<AllowedDomains> AllowedDomains { get; set; }

        [Required]
        [Display(Name = "DOMAIN NAME")]
        public string newDomainName { get; set; }
        public string Message { get; set; }
    }

    public class AllowedDomainRolesSingleVM
    {
        public AllowedDomains AllowedDomains { get; set; }
        [Required]
        [Display(Name = "DOMAIN NAME")]
        public string newDomainName { get; set; }
        public string Message { get; set; }

        public ICollection<string> AllRoles { get; set; }
    }
    public class AllowedDomainRolesVM
    {
        public IEnumerable<AllowedDomains> AllowedDomains { get; set; }
        [Required]
        [Display(Name = "DOMAIN NAME")]
        public string newDomainName { get; set; }
        public string Message { get; set; }

        public ICollection<string> AllRoles { get; set; }
    }
}
