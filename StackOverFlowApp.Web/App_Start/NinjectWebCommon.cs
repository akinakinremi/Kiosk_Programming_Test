using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.Web.Mvc;
using StackOverFlowApp.Web.DAL;
using StackOverFlowApp.Web.Interface;

namespace StackOverFlowApp.Web
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
                
                RegisterServices(kernel);

                var ninjectResolver = new NinjectDependencyResolver(kernel);
                DependencyResolver.SetResolver(ninjectResolver); //MVC
                //GlobalConfiguration.Configuration.DependencyResolver = ninjectResolver; //Web API


                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }


        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.
        private static void RegisterServices(IKernel kernel)
        {
            // unit of work per request
            kernel.Bind<IServiceManager>().To<ServiceManager>().InRequestScope();
            // default binding for everything except unit of work
           // kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().Excluding<UnitOfWork>().BindDefaultInterface());
        }
    }
}