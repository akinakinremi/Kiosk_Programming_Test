using System;
using System.IO;
using System.Web;

namespace StackOverFlowApp.Web
{
    public class Utilities
    {
        public static void LogError(string msg, string sTrace, string title)
        {

            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Error/")))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Error/"));
            }

            string ss = HttpContext.Current.Server.MapPath("~/Error/") + "\\StackOverFlowApp_Log_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            var fs = new FileStream(ss, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var s = new StreamWriter(fs);

            s.Close();

            fs.Close();

            //log it
            var fs1 = new FileStream(ss, FileMode.Append, FileAccess.Write);
            var s1 = new StreamWriter(fs1);
            s1.WriteLine("Title: " + title);
            s1.WriteLine("Message: " + msg);
            s1.WriteLine("StackTrace: " + sTrace.Replace("  ", ""));
            s1.WriteLine("Date&Time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            s1.WriteLine("===============================================================================================");
            s1.Close();
            fs1.Close();
        }
    }


}