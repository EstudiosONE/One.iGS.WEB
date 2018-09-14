using Jose;
using LiteDB;
using System;

namespace One.iGS.API.Models.Auth
{
    public class Token
    {
        public string Id { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Expiration { get; set; }
        public TokenData Data { get; set; }
        public bool RequiresNewPassword { get; set; }

        public Token() { }
        public Token(int expireMinutes = 30)
        {
            Id = ObjectId.NewObjectId().ToString();
            Creation = DateTime.UtcNow;
            Expiration = DateTime.UtcNow.AddMinutes(expireMinutes);
            Data = new TokenData();
        }

        public override string ToString()
        {
            return JWT.Encode(this, Convert.FromBase64String(WebApiApplication.Current.JWTPass), JwsAlgorithm.HS256);
        }
    }
}