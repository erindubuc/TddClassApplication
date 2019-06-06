using System.Web;
using System.Web.Mvc;

namespace Challenge_Winner_Validity
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
