using System;

namespace Ticketing.Data.TicketModel.ViewModels
{
    public class UserVM
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Boolean IsEmailVerified { get; set; }
        public string Id { get; set; }
        public Boolean IsRegistrationApproved { get; set; }
    }
}
