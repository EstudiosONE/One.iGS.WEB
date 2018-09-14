using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace One.iGS.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static LiteDB.LiteDatabase LiteDatabase { get; set; }
        internal static string LDBPass = "nNmmhjjjYYYgfdf";
        internal static string JWTPass = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
        internal static Models.WebApiApplication model = new Models.WebApiApplication(LDBPass, JWTPass);
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
