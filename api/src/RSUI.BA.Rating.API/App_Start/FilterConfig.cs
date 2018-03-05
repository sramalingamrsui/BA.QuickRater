using System.Web;
using System.Web.Mvc;

namespace RSUI.BA.Rating.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
