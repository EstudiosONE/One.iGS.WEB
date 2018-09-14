using One.iGS.API.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace One.iGS.API.Controllers.Auth
{
    [RoutePrefix("api/auth")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public string Login([FromBody]Model.Request.Login cred)
        {
            // Verificar que los datos no sean nulos
            if (cred == default(Model.Request.Login) || cred == null) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (cred.User == default(string) || cred.User == null) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (cred.Pass == default(string) || cred.Pass == null) throw new HttpResponseException(HttpStatusCode.BadRequest);

            // Generar conversiones necesarias
            cred.User = cred.User.ToUpper();

            var securityEntity = WebApiApplication.LiteDatabase.GetCollection<SecurityEntity>();
            var securiyPass = WebApiApplication.LiteDatabase.GetCollection<SecurityPass>();

            // Verificar los datos para autorizar el login
            var user = securityEntity.FindOne(x => x.EntityName == cred.User);
            if (user == null) throw new HttpResponseException(HttpStatusCode.Unauthorized);
            if (user.State != "ACTIVE") throw new HttpResponseException(HttpStatusCode.Unauthorized);
            var pass = securiyPass.FindById(user.SecurityPassId);
            if (pass.Secret != Tools.HASH.GenerateFromString(cred.Pass)) throw new HttpResponseException(HttpStatusCode.Unauthorized);

            // Generar el token
            var result = Tools.Token.GenerateToken(user, pass.ReplacedOn).ToString();

            // Responder solicitud
            return result;
        }

        public class Model
        {
            public class Request
            {
                public class Login
                {
                    public string User { get; set; }
                    public string Pass { get; set; }
                }
            }
        }
    }
}
