using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirlineManagementAPI.Models
{
    public partial class Card
    {
        public string UserId { get; set; }
        public string CardNo { get; set; }
        public string CardType { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual Users User { get; set; }
    }
}
