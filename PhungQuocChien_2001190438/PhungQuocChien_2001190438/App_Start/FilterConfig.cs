using System.Web;
using System.Web.Mvc;

namespace PhungQuocChien_2001190438
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}