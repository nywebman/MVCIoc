using System;
using MVCIoc.Models;
using MVCIoc.Pages;

[assembly: WebActivator.PostApplicationStartMethod(typeof(MVCIoc.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace MVCIoc.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Linq;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? Go to: https://bit.ly/YE8OJj.
            var container = new Container();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();

            //------dependancy resolver----------
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            //----------------
        }
     
        private static void InitializeContainer(Container container)
        {
            var repositoryAssemby = typeof (MvcApplication).Assembly;

            var registration =
                from type in repositoryAssemby.GetExportedTypes()  //get all types
                where type.Namespace.Contains("MVCIoc.Models")   //limit to the ones in models
                where type.GetInterfaces().Any()
                select new                              //get 2 piecs of info from each assembly
                {
                    Service = type.GetInterfaces().First(),
                    Implementation = type
                };

            foreach (var reg in registration)
            {
                container.Register(reg.Service,reg.Implementation,Lifestyle.Transient); //transient means not making singleton
            }

            container.RegisterInitializer<ProteinTrackerBasePage>(
                p=>p.AnalyticService=container.GetInstance<IAnalyticService>());  //this is for property injection since simple inject doesnt do it by default
        }
    }
}