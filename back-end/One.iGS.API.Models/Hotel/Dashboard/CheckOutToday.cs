using System;
using System.Collections.Generic;
using System.Text;

namespace One.iGS.API.Models.Hotel.Dashboard
{
    public class CheckOutToday : ReservationBase
    {
        public bool Released { get; set; }
        public DateTime ReleaseTime { get; set; }
    }
}
