using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common.WebHost;
using StackOverFlowApp.Web.DAL;
using StackOverFlowApp.Web.Interface;

namespace StackOverFlowApp.Web
{
    //public class MvcApplication : System.Web.HttpApplication
    //{
    //    protected void Application_Start()
    //    {
    //        //NinjectContainer.RegisterModules(NinjectModules.Modules);
    //        AreaRegistration.RegisterAllAreas();
    //        GlobalConfiguration.Configure(WebApiConfig.Register);
    //        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    //        RouteConfig.RegisterRoutes(RouteTable.Routes);
    //        BundleConfig.RegisterBundles(BundleTable.Bundles);
    //    }
    //}

    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IServiceManager>().To<ServiceManager>();
            kernel.Bind<IServiceOperation>().To<ServiceOperation>();
            kernel.Bind<IUrlService>().To<UrlService>();
            return kernel;
        }
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            //NinjectContainer.RegisterModules(NinjectModules.Modules);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
