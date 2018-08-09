using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ticketing.Identity;
using Ticketing.TicketModel;

namespace Ticketing.Data.Repository
{
    public interface IRolesRepository
    {
        IEnumerable<IdentityRole> GetAll();
        ICollection<ApplicationRole> GetAllApp();
        AllowedDomains getAllowedDomainByID(int Id);
        void AddRole(ApplicationRole applicationRole);
        void deleteRoles(string Id);
        List<string> GetUserRoles(string Id);
    }

    public class RolesRepository : IRolesRepository
    {
        private readonly ApplicationDbContext _context;
        public RolesRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public IEnumerable<IdentityRole> GetAll()
        {
            var ret = _context.Roles.ToList();
            return ret;
        }

        public ICollection<ApplicationRole> GetAllApp()
        {
            return _context.Roles.ToList();
        }

        public AllowedDomains getAllowedDomainByID(int Id)
        {
            return _context.AllowedDomains.Where(d => d.RecID == Id).FirstOrDefault();
        }

        public void AddRole(ApplicationRole applicationRole)
        {
            _context.Roles.Add(applicationRole);
            // _context.SaveChanges();


        }

        public void deleteRoles(string Id)
        {
            var delete = new ApplicationRole { Id = Id };
            _context.Roles.Attach(delete);
            _context.Roles.Remove(delete);
            //_context.SaveChanges();
        }

        public List<string> GetUserRoles(string Id)
        {

            var m = _context.Users.Find(Id).Roles;

            return new List<string>();
        }
    }
}