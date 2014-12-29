using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MVCIoc.Filters;
using MVCIoc.Models;
using MVCIoc.Pages;

namespace MVCIoc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterAutoFac();

            AreaRegistration.RegisterAllAreas();

           // WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        private void RegisterAutoFac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());

            builder.RegisterType<DebugMessageService>().As<IDebugMessageService>();
            builder.RegisterType<DebugFilter>();                                     //so filter will work
            builder.RegisterType<AnalyticService>().As<IAnalyticService>();
            builder.RegisterType<ProteinTrackerBasePage>().PropertiesAutowired();   //so property injection works, no attrib needed on ProteinTrackerBasePage
            builder.RegisterType<ProteinTrackingService>().As<IProteinTrackingService>();
            builder.RegisterType<ProteinRepository>().As<IProteinRepository>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}