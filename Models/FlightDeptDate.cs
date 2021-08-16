using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirlineManagementAPI.Models
{
    public partial class FlightDeptDate
    {
        public string FlightNo { get; set; }
        public string DeptDate { get; set; }
        public int SeatsB { get; set; }
        public int SeatsE { get; set; }
    }
}
