using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using One.iGS.API.Models.Auth;

namespace One.iGS.API.Controllers.Hotel
{
    [RoutePrefix("api/hotel/reservation")]
    public class ReservationController : ApiController
    {
        [HttpGet]
        [Route("dashboard/check-in-today")]
        public List<Models.Hotel.Dashboard.CheckInToday> CheckInToday()
        {
            //var token = Tools.Token.VerifyRequest(Request, $"{EntityRight.Zone.Management}.{EntityRight.Module.Hotel}.{EntityRight.SubModule.Dashboard}.{EntityRight.Section.CheckInToday}.{EntityRight.Action.Base}");
            var token = Tools.Token.VerifyRequest(Request);
            return Driver.Hotel.Dashboard.CheckInToday();
        }
        [HttpGet]
        [Route("dashboard/check-out-today")]
        public List<Models.Hotel.Dashboard.CheckOutToday> CheckOutToday()
        {
            //var token = Tools.Token.VerifyRequest(Request, $"{EntityRight.Zone.Management}.{EntityRight.Module.Hotel}.{EntityRight.SubModule.Dashboard}.{EntityRight.Section.CheckInToday}.{EntityRight.Action.Base}");
            var token = Tools.Token.VerifyRequest(Request);
            return Driver.Hotel.Dashboard.CheckOutToday();
        }
        [HttpGet]
        [Route("dashboard/pending-reservations")]
        public List<Models.Hotel.Dashboard.PendingReservation> PendingReservations()
        {
            //var token = Tools.Token.VerifyRequest(Request, $"{EntityRight.Zone.Management}.{EntityRight.Module.Hotel}.{EntityRight.SubModule.Dashboard}.{EntityRight.Section.CheckInToday}.{EntityRight.Action.Base}");
            var token = Tools.Token.VerifyRequest(Request);
            return Driver.Hotel.Dashboard.PendingReservation();
        }
    }
}
