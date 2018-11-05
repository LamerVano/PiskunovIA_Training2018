using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HW_14
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Home/Start",
               url: "Home",
               defaults: new { controller = "Home", action = "Start" }
            );

            routes.MapRoute(
               name: "Math/Arithmetic",
               url: "Arithmetic",
               defaults: new { controller = "Math", action = "Arithmetic" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Randomizers", action = "StartPage" }
            );
        }
    }
}
