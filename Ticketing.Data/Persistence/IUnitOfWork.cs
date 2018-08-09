using Ticketing.Data.Repository;
using Ticketing.Identity;

namespace Ticketing.Data.Persistence
{
    public interface IUnitOfWork
    {
        IAllowedDomainRepository allowedDomains { get; }
        IRolesRepository Roles { get; }
        IAccountRepository Account { get; }
        IProposalRepository Proposals { get; }
        IEmailSettingRepository EmailSetting { get;  }
        IDepartmentRepository Degrees { get; }
        IDepartmentRepository Departments { get; }
        IEmailRepository Email { get; }
        ISystemSettingsRepository SystemSettings { get; }
        
        void Complete();
    }
}