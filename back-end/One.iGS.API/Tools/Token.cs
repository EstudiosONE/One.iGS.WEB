using Jose;
using One.iGS.API.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace One.iGS.API.Tools
{
    public class Token
    {
        public static Models.Auth.Token GenerateToken(SecurityEntity securityEntity, DateTime? ReplacedOne = null, int expireMinutes = 30)
        {
            var token_Collection = WebApiApplication.LiteDatabase.GetCollection<Models.Auth.Token>();
            var peopleCol = WebApiApplication.LiteDatabase.GetCollection<Models.Common.People>();

            Models.Auth.Token token = new Models.Auth.Token(expireMinutes);
            token.Data.EntityId = securityEntity.Id;

            token.Data.Rights = GetRights(securityEntity.Id);

            if (ReplacedOne.HasValue)
                if (ReplacedOne.Value < DateTime.UtcNow)
                {
                    token.RequiresNewPassword = true;
                    token.Data.Rights = new List<string>();
                }

            token_Collection.Insert(token);

            return token;
        }

        public static Models.Auth.Token VerifyRequest(HttpRequestMessage Request, string right = null)
        {
            // Verificar que exista una autorizacion en el header
            if (Request.Headers.Authorization == null) throw new HttpResponseException(HttpStatusCode.Unauthorized);

            // Obtener el token
            var token = VerifyToken(Request.Headers.Authorization.Parameter);
            if (token == null) throw new HttpResponseException(HttpStatusCode.Unauthorized);

            // Actualizar el token
            HttpContext.Current.Response.Headers.Add("Authorization", token.ToString());

            // Verificar el permiso
            if (right != null)
                if (!token.Data.Rights.Exists
                    (x => x == right))
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);

            // Devolver el Token
            return token;
        }

        public static Models.Auth.Token VerifyToken(string _token, int expireMinutes = 30)
        {
            try
            {
                var token = JWT.Decode<Models.Auth.Token>(_token, Convert.FromBase64String(WebApiApplication.JWTPass));
                if (token.Expiration < DateTime.UtcNow) return null;
                var entity = WebApiApplication.LiteDatabase.GetCollection<SecurityEntity>().FindById(token.Data.EntityId);
                if (entity == null) return null;
                if (entity.State != "ACTIVE") return null;
                var tokenCol = WebApiApplication.LiteDatabase.GetCollection<Models.Auth.Token>();
                token.Expiration = DateTime.UtcNow.AddMinutes(expireMinutes);
                tokenCol.Update(token);

                return token;
            }
            catch (JoseException)
            {
                return null;
            }
        }

        public static List<string> GetRights(string entityId)
        {
            var entityCol = WebApiApplication.LiteDatabase.GetCollection<Models.Auth.SecurityEntity>();

            List<string> rights = new List<string>();

            var entity = entityCol.FindById(entityId);
            if (entity == null) return rights;
            if (entity.State != "ACTIVE") return rights;

            foreach (var right in entity.EntityRightsId)
            {
                if (!rights.Exists(x => x == right)) rights.Add(right);
            }

            if (entity.InheritancesId.Count > 0)
                foreach (var entityInheritances in entity.InheritancesId)
                {
                    var result = GetRights(entityInheritances);

                    foreach (var rightInheritances in result)
                    {
                        if (!rights.Exists(x => x == rightInheritances)) rights.Add(rightInheritances);
                    }
                }

            return rights;
        }
    }
}