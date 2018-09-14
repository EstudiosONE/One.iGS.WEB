using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace One.iGS.API.Models.Auth
{
    public class SecurityEntity : ModelBase<SecurityEntity>, ICloneable
    {
        public string Id { get; set; }
        public string EntityName { get; set; }
        public string EntityDescription { get; set; }
        public string EntityType { get; set; }
        public string PeopleId { get; set; }
        public List<string> EntityRightsId { get; set; }
        public List<string> InheritancesId { get; set; }
        public string SecurityPassId { get; set; }
        public string State { get; set; }

        public SecurityEntity()
        {
            Id = ObjectId.NewObjectId().ToString();
            EntityRightsId = new List<string>();
            InheritancesId = new List<string>();
            Log = new AuditLog<SecurityEntity>();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}