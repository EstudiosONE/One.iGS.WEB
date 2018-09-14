using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace One.iGS.API.Models.Auth
{
    public class SecurityPass
    {
        public string Id { get; set; }
        public string EntityId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Replaced { get; set; }
        public string Secret { get; set; }
        public DateTime? ReplacedOn { get; set; }

        public SecurityPass()
        {
            Id = ObjectId.NewObjectId().ToString();
            Created = DateTime.UtcNow;
        }
        public SecurityPass(string entityId, string secret)
        {
            Id = ObjectId.NewObjectId().ToString();
            Created = DateTime.UtcNow;
            EntityId = entityId;
            Secret = secret;
        }
        public SecurityPass(string entityId, string secret, DateTime? replacedOn)
        {
            Id = ObjectId.NewObjectId().ToString();
            Created = DateTime.UtcNow;
            EntityId = entityId;
            Secret = secret;
            ReplacedOn = replacedOn;
        }
    }
}