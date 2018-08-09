using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticketing.Entity.TicketModel;
using Ticketing.Identity;

namespace Ticketing.Data.Repository
{
    public interface ISystemSettingsRepository
    {
        ICollection<SystemSettings> GetCurrentConfigurationFor(string ConfigurationFor);
    }
    public class SystemSettingsRepository : ISystemSettingsRepository
    {
        private readonly ApplicationDbContext _context;
        public SystemSettingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<SystemSettings> GetCurrentConfigurationFor(string ConfigurationFor)
        {
            var _EmailSetting = _context.SystemSettings.Where(w => w.ConfigurationFor.Equals(ConfigurationFor));

           return _EmailSetting.Where(w => w.ConfigurationFor.Equals(ConfigurationFor) && w.Version.Equals(_EmailSetting.Max(x => x.Version))).ToList();

        }
    }
}