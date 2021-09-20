using System.Web;
using System.Web.Mvc;

namespace P1_AquariumFishStore_TeamAkshay
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
