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
        public List<Models.Hotel.Dashboard.PendingReservation> GetAll()
        {
            //var token = Tools.Token.VerifyRequest(Request, $"{EntityRight.Zone.Management}.{EntityRight.Module.Hotel}.{EntityRight.SubModule.Dashboard}.{EntityRight.Section.CheckInToday}.{EntityRight.Action.Base}");
            var token = Tools.Token.VerifyRequest(Request);
            try
            {
                return Driver.Hotel.Dashboard.PendingReservation();
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
    }
}
