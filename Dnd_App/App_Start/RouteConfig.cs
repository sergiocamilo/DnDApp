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
                url: "panel",
                defaults: new { controller = "User", action = "Panel" }
            );

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "User", action = "Login" }
            );

            routes.MapRoute(
                name: "Register",
                url: "register",
                defaults: new { controller = "User", action = "Register" }
            );

            routes.MapRoute(
               name: "Validate",
               url: "validate",
               defaults: new { controller = "User", action = "Validate" }
           );

            routes.MapRoute(
                name: "NewNPC",
                url: "newNPC",
                defaults: new { controller = "NPC", action = "New"}
            );

            routes.MapRoute(
                name: "NewPC",
                url: "newPC",
                defaults: new { controller = "PC", action = "New" }
            );

            routes.MapRoute(
                name: "NewCombat",
                url: "newCombat",
                defaults: new { controller = "Combat", action = "New" }
            );

            routes.MapRoute(
                name: "StartCombat",
                url: "DoCombat/{TempID}",
                defaults: new { controller = "Combat", action = "Generate", TempID = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "MyCombats",
                url: "MyCombats",
                defaults: new { controller = "Combat", action = "Join"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );



        }
    }
}
