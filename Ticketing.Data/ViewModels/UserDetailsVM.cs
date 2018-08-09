using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ticketing.TicketModel;

namespace Ticketing.Data.TicketModel.ViewModels
{
    public class UserDetailsVM
    {
        public UserDetailsVM()
        {
            Tickets = new List<Ticket>();
            UserRoles = new List<UserRoleVM>();
            AllRoles = new List<string>();

        }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Email Verfication Status")]
        public Boolean IsEmailVerified { get; set; }

        [Display(Name = "User ID")]
        public string Id { get; set; }

        [Display(Name ="User Roles")]
        public ICollection<UserRoleVM> UserRoles { get;  set; }

        [Display(Name = "Is Registration Approved")]
        public Boolean IsRegistrationApproved { get; set; }

        [Display(Name = "Disable user")]
        public Boolean IsUserDisabled { get; set; }

        [Display(Name = "Login History")]
        public string LoginHistory { get; set; }

        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Tickets")]
        public virtual ICollection<Ticket> Tickets {get; set;}

        public string MatriculationNumber { get; set; }

        public ICollection<string> AllRoles { get; set; }
    }
}
