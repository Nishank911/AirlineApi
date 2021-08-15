using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirlineManagementAPI.Models
{
    public partial class Passenger
    {
        public string TicketNo { get; set; }
        public string Seatno { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ClassT { get; set; }

        public virtual TicketDetails TicketNoNavigation { get; set; }
    }
}
