using System;
using System.Collections.Generic;
using System.Text;

namespace One.iGS.API.Models
{
    public class WebApiApplication
    {
        internal readonly string LDBPass = "nNmmhjjjYYYgfdf";
        internal readonly string JWTPass = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
        internal static WebApiApplication Current;

        public WebApiApplication(string _LDBPass, string _JWTPass)
        {
            LDBPass = _LDBPass;
            JWTPass = _JWTPass;
            Current = this;
        }
    }
}
