using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyDrSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)

        {
           
           
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("hakkimdaRoute", "hakkimizda", new { controller = "Home", action = "About" }, namespaces: new string[] { "MyDrSite.Controllers" });
            routes.MapRoute("kitaplarRoute", "Kitap", new { controller = "Home", action = "Books" }, namespaces: new string[] { "MyDrSite.Controllers" });
            routes.MapRoute("filmlerRoute", "Film", new { controller = "Home", action = "Films" }, namespaces: new string[] { "MyDrSite.Controllers" });
            routes.MapRoute("iletisimRoute", "iletisim", new { controller = "Home", action = "Contact" }, namespaces: new string[] { "MyDrSite.Controllers" });
            routes.MapRoute("kvkkRoute", "kisisel-verilere-iliskin-aydinlatma-metni", new { controller = "Home", action = "Kvkk" }, namespaces: new string[] { "MyDrSite.Controllers" });
            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MyDrSite.Controllers" }
            );
        }
    }
}
