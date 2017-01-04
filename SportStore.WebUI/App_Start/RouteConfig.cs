using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("MyRoute2", "Strona{page}",
                new { Controller = "Product", Action = "List", category = (string)null }, new { page = @"\d" });

            routes.MapRoute("MyRoute", "Admin/{action}",
                new { Controller = "Admin", Action = "Index" });

            //routes.MapRoute("MyRoute1", "{controller}/{action}",
            //    new { Controller = "Product", Action = "List", category = (string)null, page = 1 });



            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new { Controller = "Product", Action = "List", category = (string)null, page = 1 }
            );

            routes.MapRoute(null,
                "Strona{page}",
                new { Controller = "Product", Action = "List", category = (string)null },
                new { page = @"\d" }
            );

            routes.MapRoute(null,
                "{category}",
                new { Controller = "Product", Action = "List", page = 1 }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
