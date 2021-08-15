using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirlineManagementAPI.Models
{
    public partial class TicketDetails
    {
        public TicketDetails()
        {
            Passenger = new HashSet<Passenger>();
        }

        public string TicketNo { get; set; }
        public string UserId { get; set; }
        public string FlightNo { get; set; }
        public string FDeptDt { get; set; }
        public int SeatsBookedB { get; set; }
        public int SeatsBookedE { get; set; }
        public string Status { get; set; }

        public virtual Flight FlightNoNavigation { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Passenger> Passenger { get; set; }
    }
}
