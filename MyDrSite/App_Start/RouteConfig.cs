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

            routes.MapRoute("hakkimdaRoute", "hakkimizda", new { controller = "Home", action = "About" });
            routes.MapRoute("kitaplarRoute", "Kitap", new { controller = "Home", action = "Books" });
            routes.MapRoute("filmlerRoute", "Film", new { controller = "Home", action = "Films" });
            routes.MapRoute("iletisimRoute", "iletisim", new { controller = "Home", action = "Contact" });
            routes.MapRoute("kvkkRoute", "kisisel-verilere-iliskin-aydinlatma-metni", new { controller = "Home", action = "Kvkk" });
            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MyDrSite.Controllers" }
            );
        }
    }
}
