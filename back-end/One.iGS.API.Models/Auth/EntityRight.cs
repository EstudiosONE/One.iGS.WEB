using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace One.iGS.API.Models.Auth
{
    public class EntityRight
    {
        public string Id { get; set; }
        public string Description { get; set; }

        // Base
        public static List<EntityRight> entityRights = new List<EntityRight>()
        {
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.Hotel}.{(int)SubModule.Base}.{(int)Section.Base}.{(int)Action.Base}",                                     Description = "Hotel" },
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.Hotel}.{(int)SubModule.Dashboard}.{(int)Section.Base}.{(int)Action.Base}",                                Description = "Hotel | Dashboard" },
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.Hotel}.{(int)SubModule.Dashboard}.{(int)Section.CheckInToday}.{(int)Action.Base}",                        Description = "Hotel | Dashboard | Ingresos hoy" },
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.Hotel}.{(int)SubModule.Dashboard}.{(int)Section.CheckOutToday}.{(int)Action.Base}",                       Description = "Hotel | Dashboard | Salidas hoy" },
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.Hotel}.{(int)SubModule.Dashboard}.{(int)Section.PendingReservation}.{(int)Action.Base}",                  Description = "Hotel | Dashboard | Reservas pendientes" },
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.ControlPanel}.{(int)SubModule.Security}.{(int)Section.SecurityEntities}.{(int)Action.Base}",              Description = "Security Entities" },
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.ControlPanel}.{(int)SubModule.Security}.{(int)Section.SecurityEntities}.{(int)Action.Detail}",            Description = "Security Entities | Detail" },
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.ControlPanel}.{(int)SubModule.Security}.{(int)Section.SecurityEntities}.{(int)Action.Create}",            Description = "Security Entities | Create" },
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.ControlPanel}.{(int)SubModule.Security}.{(int)Section.SecurityEntities}.{(int)Action.Update}",            Description = "Security Entities | Update" },
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.ControlPanel}.{(int)SubModule.Security}.{(int)Section.SecurityEntities}.{(int)Action.Delete}",            Description = "Security Entities | Delete" },
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.ControlPanel}.{(int)SubModule.Security}.{(int)Section.SecurityEntities}.{(int)Action.Reset}",             Description = "Security Entities | Reset" },
            new EntityRight(){ Id = $"{(int)Zone.Management}.{(int)Module.ControlPanel}.{(int)SubModule.Security}.{(int)Section.SecurityEntities}.{(int)Action.Audit}",             Description = "Security Entities | Audit" },
        };

        public enum Zone
        {
            Portal = 10,
            Management = 19
        }

        public enum Module
        {
            Hotel = 1010,
            ControlPanel = 9000
        }

        public enum SubModule
        {
            // Common
            Base = 1000,

            // Hotel
            Dashboard = 1001,
            Security = 1001
        }

        public enum Section
        {
            // Common
            Base = 1000,

            // Hotel
            CheckInToday = 1001,
            CheckOutToday = 1002,
            PendingReservation = 1003,

            // Control Panel
            SecurityEntities = 1001,
        }

        public enum Action
        {
            Base = 1000,
            Detail = 1001,
            Create = 1002,
            Update = 1003,
            Delete = 1004,
            Reset = 8000,
            Audit = 9000,
        }
    }
}