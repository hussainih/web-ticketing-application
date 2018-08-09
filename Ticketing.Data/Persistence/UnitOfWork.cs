using System.Diagnostics;
using Ticketing.Data.Repository;
using Ticketing.Identity;

namespace Ticketing.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        
        public IEmailRepository Email { get; set; }
        public IAllowedDomainRepository allowedDomains { get; private set; }
        public IRolesRepository Roles { get; private set; }
        public IAccountRepository Account { get; private set; }
        public IProposalRepository Proposals { get; private set; }
        public IEmailSettingRepository EmailSetting { get; private set; }
        public IDepartmentRepository Degrees { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public ISystemSettingsRepository SystemSettings { get; private set; }

      

        public UnitOfWork(ApplicationDbContext context,
            IAllowedDomainRepository domain,
            IRolesRepository roles,
            IAccountRepository account,
            IEmailSettingRepository emailSetting,
            IDepartmentRepository department,
            IEmailRepository email,
            ISystemSettingsRepository systemsettings,
            IProposalRepository proposal)
        {
            _context = context;
           
            allowedDomains = domain;
            EmailSetting = emailSetting;
            Roles = roles;
            Account = account;
            Departments = department;
            Email = email;
            SystemSettings = systemsettings;
            Proposals = proposal;
        }

        public void Complete()
        {
            Debug.WriteLine("This is from UnitOfWork.Complete");
            _context.SaveChanges();
           
        }
    }
}