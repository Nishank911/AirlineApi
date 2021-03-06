using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirlineManagementAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            TicketDetails = new HashSet<TicketDetails>();
        }

        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Dob { get; set; }
        public decimal PhoneNo { get; set; }

        public virtual ICollection<TicketDetails> TicketDetails { get; set; }
    }
}
