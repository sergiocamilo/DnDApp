using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dnd_App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
                name: "Panel",
                url: "Panel",
                defaults: new { controller = "User", action = "Panel"}
            );
            
            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "User", action = "Login" }
            );

            routes.MapRoute(
                name: "Register",
                url: "Register",
                defaults: new { controller = "User", action = "Register" }
            );

            routes.MapRoute(
               name: "Validate",
               url: "Validate",
               defaults: new { controller = "User", action = "Validate" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );



        }
    }
}
