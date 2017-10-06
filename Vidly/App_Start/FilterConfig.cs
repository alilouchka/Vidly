using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); // Redirect to error page when Error event is handled
            filters.Add(new AuthorizeAttribute());  
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
