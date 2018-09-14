using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace One.iGS.API.Models
{
    public class ModelBase<T>
    {
        public AuditLog<T> Log { get; set; }

        public ModelBase()
        {
            Log = new AuditLog<T>();
        }
    }

    public class AuditLog<T>
    {
        public Created Created { get; set; }
        public Updated<T> Updated { get; set; }
        public Deleted Deleted { get; set; }

        public AuditLog()
        {
            Created = new Created();
            Updated = new Updated<T>();
        }
    }

    public class Created
    {
        public DateTime DateTime { get; set; }
        public string EntityId { get; set; }

        public Created() { }
        public Created(DateTime dateTime, string entityId)
        {
            DateTime = dateTime;
            EntityId = entityId;
        }
    }
    public class Updated<T>
    {
        public List<Update> Updates { get; set; }

        public class Update
        {
            public DateTime DateTime { get; set; }
            public string EntityId { get; set; }
            public SnapObject Snap { get; set; }

            public Update() { }
            public Update(DateTime dateTime, string entityId, Tuple<T, T> snap)
            {
                DateTime = dateTime;
                EntityId = entityId;
                Snap = new SnapObject() { Before = Newtonsoft.Json.JsonConvert.SerializeObject(snap.Item1), After = Newtonsoft.Json.JsonConvert.SerializeObject(snap.Item2) };
            }

            public class SnapObject
            {
                public string Before { get; set; }
                public string After { get; set; }
            }

        }

        public Updated()
        {
            Updates = new List<Update>();
        }
    }
    public class Deleted
    {
        public DateTime DateTime { get; set; }
        public string EntityId { get; set; }

        public Deleted() { }

        public Deleted(DateTime dateTime, string entityId)
        {
            DateTime = dateTime;
            EntityId = entityId;
        }
    }
}