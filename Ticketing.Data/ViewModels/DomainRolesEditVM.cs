using System.Collections.Generic;

namespace Ticketing.Data.TicketModel.ViewModels
{
    public class DomainRolesEditVM
    {
        public string DomainName { get; set; }
        public ICollection<string> DomainRoles { get; set; }
    }
}
