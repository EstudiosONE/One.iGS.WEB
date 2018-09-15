using System;
using System.Collections.Generic;
using System.Text;

namespace One.iGS.API.Models.Hotel.Dashboard
{
    public class CheckInToday : ReservationBase
    {
        public bool Confirmation { get; set; }
        public bool Ocupation { get; set; }
        public DateTime EntryTime { get; set; }
    }
}
