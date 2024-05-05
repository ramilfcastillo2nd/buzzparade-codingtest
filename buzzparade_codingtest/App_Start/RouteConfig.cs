using buzzparade_codingtest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace buzzparade_codingtest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //call seedata initialiaze method 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Survey", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
