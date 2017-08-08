using Autofac;
using Autofac.Integration.Web;
using ConsumersTest._IoC;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace ConsumersTest
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        // Provider that holds the application container.
        private static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider => _containerProvider;

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterIoC();
        }

        private static void RegisterIoC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AppModule>();
            _containerProvider = new ContainerProvider(builder.Build());
        }        
    }
}