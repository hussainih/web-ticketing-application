using System.Collections.Generic;
using Ticketing.Identity;
using Ticketing.TicketModel;

using System.Data.Entity;
using System.Linq;

namespace Ticketing.Data.Repository
{
    public interface IAllowedDomainRepository
    {
         IEnumerable<AllowedDomains> GetAll();
        AllowedDomains getDomainByName(string domainName);
        void AddManyRolesToADomain(string domainName, IEnumerable<string> Roles);
        void AddaDomainByName(string newDomainName);
        void AddaRoleToDomain(string domainName, string roleName);
        void RemovedRoleFromADomain(string domainName, string roleName);
    }


    public class AllowedDomainRepository : IAllowedDomainRepository
    {
        private readonly ApplicationDbContext _context;

        public AllowedDomainRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AllowedDomains> GetAll()
        {
            return _context.AllowedDomains.Include(a => a.Roles).ToList();
        }

        public AllowedDomains getDomainByName(string domainName)
        {
            return _context.AllowedDomains.Where(a => a.DomainName.Equals(domainName)).FirstOrDefault();
        }

        public void AddManyRolesToADomain(string domainName, IEnumerable<string> Roles)
        {

            var domain = _context.AllowedDomains.Where(a => a.DomainName == domainName).FirstOrDefault();
            domain.Roles.Clear();
            if (Roles != null)
                foreach (var role in Roles)
                {
                    domain.Roles.
                         Add(_context.Roles.Where(r => r.Name.Equals(role)).FirstOrDefault());
                }
            //_context.SaveChanges();
        }

        public void AddaDomainByName(string DomainName)
        {
            _context.AllowedDomains.Add(new AllowedDomains
            {
                DomainName = DomainName

            });
            // _context.SaveChanges();
        }

        public void AddaRoleToDomain(string domainName, string roleName)
        {
            _context.AllowedDomains.Where(a => a.DomainName == domainName).FirstOrDefault()
                .Roles.Add(_context.Roles.Where(r => r.Name == roleName).FirstOrDefault());
        }

        public void RemovedRoleFromADomain(string domainName, string roleName)
        {
            _context.AllowedDomains.Where(a => a.DomainName == domainName).FirstOrDefault()
                .Roles.Remove(_context.Roles.Where(r => r.Name == roleName).FirstOrDefault());
        }
    }
}