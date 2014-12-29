using System;
using System.Net.Http.Headers;
using System.Web.Configuration;
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

        //switch depending on config
        container.RegisterType<IProteinRepository, ProteinRepository>("StandardRepository",
            new InjectionConstructor("test"));
        container.RegisterType<IProteinRepository, DebugProteinRepository>("DebugRepository");


        var repositoryType = WebConfigurationManager.AppSettings["RepositoryType"];
        container.RegisterType<IProteinTrackingService, ProteinTrackingService>(
            new InjectionConstructor(container.Resolve<IProteinRepository>(repositoryType)));

    }
  }

    public class DebugProteinRepository : IProteinRepository
    {
        public ProteinData GetData(DateTime dateTime)
        {
            return new ProteinData();
        }

        public void SetTotal(DateTime dateTime, int value)
        {
            //
        }

        public void SetGoal(DateTime dateTime, int value)
        {
            //
        }
    }
}