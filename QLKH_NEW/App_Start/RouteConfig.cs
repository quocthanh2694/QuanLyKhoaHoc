using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLKH_NEW
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "LogOut",
            url: "Log-Out",
            defaults: new { controller = "Home", action = "LogOut", id = UrlParameter.Optional }
        );

            routes.MapRoute(
              name: "Login",
              url: "Log-In",
              defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "PrintLLKHH",
               url: "In-LLKH",
               defaults: new { controller = "Home", action = "Print", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
