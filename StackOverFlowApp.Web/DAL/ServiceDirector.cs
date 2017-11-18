using System.Collections.Generic;
using StackOverFlowApp.Web.Interface;
using StackOverFlowApp.Web.Models;

namespace StackOverFlowApp.Web.DAL
{
    public class ServiceDirector 
    {
        private IServiceBuilder _objBuilder;

        public ServiceDirector(IServiceBuilder builder)
        {
            _objBuilder = builder;
        }

        public void Construct()
        {
            _objBuilder.SetMainUrl();
            _objBuilder.SetUrlPagesizeParameters();
            _objBuilder.SetUrlOrderParameters();
            _objBuilder.SetUrlSortParameters();
            _objBuilder.SetUrlSiteParameters();
        }

        public IEnumerable<Item> GetQuestions()
        {
            return _objBuilder.GetTopQuestions();
        }
    }
}