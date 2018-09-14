using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace One.iGS.API
{
    public static class WebApiConfig
    {
        internal static string dbPath;
        internal static string dbFile;

        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            var cors = new EnableCorsAttribute("*", "*", "*", "Authorization");

            config.EnableCors(cors);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            // Setear parametros de configuración para la base de datos
            dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "One", "iGS Suite");
            dbFile = System.IO.Path.Combine(dbPath, "main.db");
            var password = WebApiApplication.LDBPass;
            WebApiApplication.LiteDatabase = new LiteDB.LiteDatabase($"Filename={dbFile}; Password={password}");

            // Crear directorio de datos
            System.IO.Directory.CreateDirectory(dbPath);

            // Generar datos iniciales
            App_Start.DataBase.Auth.EntityRight();
            App_Start.DataBase.Auth.CreateSecurityEntitiesBase();
        }
    }
}
