using System.Collections.Generic;
using StackOverFlowApp.Web.Models;

namespace StackOverFlowApp.Web.Interface
{
    public interface IServiceBuilder
    {
        void SetMainUrl();
        void SetUrlPagesizeParameters();
        void SetUrlOrderParameters();
        void SetUrlSortParameters();
        void SetUrlSiteParameters();
        string GetCompleteUrl();
        IEnumerable<Item> GetTopQuestions();
    }
}
