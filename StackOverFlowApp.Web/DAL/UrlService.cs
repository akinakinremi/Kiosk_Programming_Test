using StackOverFlowApp.Web.Interface;
using System;

namespace StackOverFlowApp.Web.DAL
{
    public class UrlService : IUrlService
    {
        private readonly string serviceUrl;

        public UrlService() : this(null) {
            this.serviceUrl = "https://api.stackexchange.com/2.2/questions?pagesize=50&order=desc&sort=creation&site=stackoverflow";
        }

        public UrlService(string questionid)
        {
            this.serviceUrl = string.IsNullOrEmpty(questionid) ? "https://api.stackexchange.com/2.2/questions?pagesize=50&order=desc&sort=creation&site=stackoverflow" : string.Format("https://api.stackexchange.com/2.1/questions/{0}?order=desc&sort=activity&site=stackoverflow&filter=withbody", questionid);
        }

        public string GetServiceUrl
        {
            get { return serviceUrl; }
        }
    }
}