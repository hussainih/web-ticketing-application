using System;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Ticketing;
using Ticketing.Data.Persistence;
using Ticketing.Data.Repository;
using Ticketing.Identity;

namespace Ticketing
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }


        private static void RegisterTypes(IUnityContainer container)
        {

            container.RegisterType<ApplicationDbContext>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationSignInManager>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationUserManager>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationRoleManager>(new PerRequestLifetimeManager());

            container.RegisterType<IProposalRepository, ProposalRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ISystemSettingsRepository, SystemSettingsRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IEmailRepository, EmailRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IDepartmentRepository, DepartmentRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IRolesRepository, RolesRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IAllowedDomainRepository, AllowedDomainRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IEmailSettingRepository, EmailSettingRepository>(new PerRequestLifetimeManager());

            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
                new InjectionConstructor(typeof(ApplicationDbContext)));

            

            container.RegisterType<IRoleStore<ApplicationRole, string>, RoleStore<ApplicationRole, string, IdentityUserRole>>(
                new InjectionConstructor(typeof(ApplicationDbContext)));

            
        }
    }
}