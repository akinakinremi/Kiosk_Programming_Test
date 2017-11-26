using StackOverFlowApp.Web.Interface;
using System;

namespace StackOverFlowApp.Web.DAL
{
    public class UrlService : IUrlService
    {
        public string GetMainUrl()
        {
            return "https://api.stackexchange.com/2.2/questions?pagesize=50&order=desc&sort=creation&site=stackoverflow&filter=withbody";
        }

        public string GetUrlByQuestion(string questionId)
        {
            if (!string.IsNullOrEmpty(questionId))
            {
                return string.Format("https://api.stackexchange.com/2.1/questions/{0}?order=desc&sort=activity&site=stackoverflow&filter=withbody", questionId);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}