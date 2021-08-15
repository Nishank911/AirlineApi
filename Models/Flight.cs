using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirlineManagementAPI.Models
{
    public partial class Flight
    {
        public Flight()
        {
            TicketDetails = new HashSet<TicketDetails>();
        }

        public string FlightNo { get; set; }
        public string FromLoc { get; set; }
        public string ToLoc { get; set; }
        public string DepartTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Duration { get; set; }
        public int Business { get; set; }
        public int Economy { get; set; }
        public decimal PriceB { get; set; }
        public decimal PriceE { get; set; }

        public virtual ICollection<TicketDetails> TicketDetails { get; set; }
    }
}
