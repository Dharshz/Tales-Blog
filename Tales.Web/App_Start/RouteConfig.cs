using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tales.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //    name: "Post",
        //    url: "{controller}/{action}/{postId}",
        //    defaults: new { controller = "Post", action = "ShowPost", postId = 1 }
        //);
            routes.MapRoute(
                       name: "Post",
                       url: "Post/ShowPost/{postId}",
                       defaults: new { controller = "Post", action = "ShowPost", postId = 1 }
                   );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional }
            );

         
        }
    }
}
