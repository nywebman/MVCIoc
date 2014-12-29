using System.Web;
using System.Web.Mvc;
using MVCIoc.Filters;

namespace MVCIoc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
          //  filters.Add(DependencyResolver.Current.GetService<DebugFilter>());
        }
    }
}