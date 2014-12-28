using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MVCIoc.Models;
using Unity.Mvc4;

namespace MVCIoc
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterTypes(
            AllClasses.FromLoadedAssemblies(),
            WithMappings.FromMatchingInterface,
            WithName.Default);


        //using unity to manually map below, above to automate it
            //commented out below because of above code
        //container.RegisterType<IProteinTrackingService, ProteinTrackingService>();
        //container.RegisterType<IProteinRepository, ProteinRepository>();
    }
  }
}