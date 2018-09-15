using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace One.iGS.API.Log
{
    public static class Helper
    {
        public static void Notify(Exception ex)
        {
            InsertIntoLog(ex.HResult, ex.Source, ex.Message);
            Debug.Write(Newtonsoft.Json.JsonConvert.SerializeObject(ex));
        }

        private static void InsertIntoLog(int HResult, string Source, string Message)
        {
            var path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "One", "iGS Suite", "API.log");
            var line = new List<string>()
            {
                $"{DateTime.Now} | {HResult} | {Source} | {Message}"
            };
            System.IO.File.AppendAllLines(path, line);
        }
    }
}
