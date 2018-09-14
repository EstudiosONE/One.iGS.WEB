using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace One.iGS.API.App_Start.DataBase
{
    public class Auth
    {
        public static void EntityRight()
        {
            var entityRight = WebApiApplication.LiteDatabase.GetCollection<Models.Auth.EntityRight>();

            foreach (var entity in Models.Auth.EntityRight.entityRights)
            {
                if (!entityRight.Exists(x => x.Id == entity.Id)) entityRight.Insert(entity);
            }
        }
        public static void CreateSecurityEntitiesBase()
        {
            var securityEntity = WebApiApplication.LiteDatabase.GetCollection<Models.Auth.SecurityEntity>();
            var securityPass = WebApiApplication.LiteDatabase.GetCollection<Models.Auth.SecurityPass>();
            var people = WebApiApplication.LiteDatabase.GetCollection<Models.Common.People>();

            #region Entities
            Models.Auth.SecurityEntity administrators, suport;
            #endregion

            #region Administrators
            if (!securityEntity.Exists(x => x.EntityName == "ADMINISTRADORES"))
            {
                administrators = new Models.Auth.SecurityEntity()
                {
                    EntityName = "ADMINISTRADORES",
                    EntityDescription = "Grupo de permisos | Administradores",
                    EntityType = "GROUP",
                    State = "ACTIVE"
                };

                administrators.Log.Created = new Models.Created() { DateTime = DateTime.UtcNow, EntityId = null };

                securityEntity.Upsert(administrators);
            }
            else administrators = securityEntity.FindOne(x => x.EntityName == "ADMINISTRADORES");

            List<string> rights = new List<string>();
            foreach (var entity in Models.Auth.EntityRight.entityRights)
            {
                rights.Add(entity.Id);
            }

            if (!administrators.EntityRightsId.Equals(rights))
            {
                administrators.EntityRightsId = rights;
                securityEntity.Upsert(administrators);
            }
            #endregion

            #region suport
            if (!securityEntity.Exists(x => x.EntityName == "SOPORTE"))
            {
                suport = new Models.Auth.SecurityEntity()
                {
                    EntityName = "SOPORTE",
                    EntityDescription = "Usuario de sistema | Soporte",
                    EntityType = "USER",
                    InheritancesId = new List<string>
                    {
                        administrators.Id
                    },
                    State = "ACTIVE"
                };

                suport.Log.Created = new Models.Created() { DateTime = DateTime.UtcNow, EntityId = null };

                Models.Auth.SecurityPass entityPass = new Models.Auth.SecurityPass(suport.Id, Tools.HASH.GenerateFromString("igssuite"));

                suport.SecurityPassId = entityPass.Id;

                securityEntity.Upsert(suport);
                securityPass.Upsert(entityPass);
            }
            #endregion
        }
    }
}