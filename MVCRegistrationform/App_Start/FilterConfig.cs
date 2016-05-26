using MVCRegistrationform.Filters;
using System.Web;
using System.Web.Mvc;

namespace MVCRegistrationform
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new ExceptionAttribute());
        }
    }
}