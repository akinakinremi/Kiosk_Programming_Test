using StackOverFlowApp.Web.Interface;
using System.IO;
using System.Net;

namespace StackOverFlowApp.Web.DAL
{
    public class ServiceOperation : IServiceOperation
    {
        public string CallService(string serviceurl)
        {
            var request = (HttpWebRequest)WebRequest.Create(serviceurl);

            request.Method = "GET";
            // request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var response = (HttpWebResponse)request.GetResponse();

            string content;

            using (Stream stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            return content;
        }
    }
}