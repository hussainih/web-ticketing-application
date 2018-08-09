using System.Collections.Generic;
using Ticketing.Data.TicketModel.ViewModels;

using Ticketing.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Ticketing.Data.TicketModel.ViewModels;
using Ticketing.Identity;
using Ticketing;


namespace Ticketing.Data.Repository
{
    public interface IAccountRepository
    {
        ICollection<ApplicationUser> getAllUsers();
        UserRoleVM getUserByEmail(string email);
        UserRoleVM getUserByName(string name);
        UserRoleVM getUserById(string id);
        ICollection<ApplicationRole> AddRolebyEmail(string email);
        bool testRepo();
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public UserRoleVM getUserByEmail(string email)
        {
            throw new NotImplementedException();
        }


        public ICollection<ApplicationUser> getAllUsers()
        {

            var model = _context.Users.ToList();


            return model;

        }


        public UserRoleVM getUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public UserRoleVM getUserById(string id)
        {
            throw new NotImplementedException();
        }


        public bool testRepo()
        {
            throw new NotImplementedException();
        }


        public string justAName()
        {
            using (var db = new ApplicationDbContext())
            {
                return _context.Users.FirstOrDefault().Email;

            }
        }

        public IEnumerable<IdentityRole> getAllRoles()
        {
            using (var db = new ApplicationDbContext())
            {
                return _context.Roles.ToList();
            }


        }
        public void AddRole(string name)
        {

            _context.Roles.Add(new ApplicationRole { Name = name });


        }





        public ICollection<ApplicationRole> AddRolebyEmail(string email)
        {

            //var email = model.Email;
            string userMailDomain = new MailAddress(email).Host;
            var anotherUser = _context.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();

            var roles = _context.AllowedDomains
                           .Where(a => a.DomainName.Contains(userMailDomain))
                           .Include(t => t.Roles).FirstOrDefault().Roles.ToList();
            foreach (var role in roles)
            {
                IdentityUserRole identityUserRole = new IdentityUserRole();
                identityUserRole.RoleId = role.Id;
                identityUserRole.UserId = anotherUser.Id;
                anotherUser.Roles.Add(identityUserRole);
            }

            
            return roles;

        }
    }
}