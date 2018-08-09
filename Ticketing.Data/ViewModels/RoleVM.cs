using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ticketing.Entity.Resources;

namespace Ticketing.Data.TicketModel.ViewModels
{
    public class RoleVM
    {
        [Required]
        [Display(Name = "Role", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordRangeError", MinimumLength = 3)]
        
        public string Name { get; set; } //Get the Value for New Role from User
        public IEnumerable<IdentityRole> Roles { get; set; }
        public string Message { get; set; } //Feedback to User
    }
}
