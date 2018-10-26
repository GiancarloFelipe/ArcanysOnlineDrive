using System.Web;
using System.Web.Mvc;

namespace ArcanysSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Adds the specified filter to the global filter collection.
            filters.Add(new HandleErrorAttribute());
        }
    }
}
