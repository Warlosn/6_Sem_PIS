using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using Lab4a.CustomRouter;

namespace Lab4a
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add(new Route("custom_route", new CustomRouteHandler()));


            #region M01
            //первые 4
            routes.MapRoute(
                name: "route1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MResearch", action = "M01", id = UrlParameter.Optional },
                constraints: new { controller = "|MResearch", action = "|M01", id = "|1" }
            );

            //5
            routes.MapRoute(
                name: "route2",
                url: "V2/{controller}/{action}",
                defaults: new {},
                constraints: new { controller = "MResearch", action = "M01" }
            );

            //6
            routes.MapRoute(
                name: "route3",
                url: "V3/{controller}/X/{action}",
                defaults: new { },
                constraints: new { controller = "MResearch", action = "M01" }
            );
            #endregion

            #region M02
            //первые 3
            routes.MapRoute(
                name: "route4",
                url:  "V2/{controller}/{action}",
                defaults: new { controller = "MResearch", action = "M02"},
                constraints: new { controller= "MResearch", action = "M02" }
            );

            //4
            routes.MapRoute(
                name: "route5",
                url: "{controller}/{action}",
                defaults: new {},
                constraints: new { controller = "MResearch", action = "M02" }
            );

            //5
            routes.MapRoute(
                name: "route6",
                url: "V3/{controller}/X/{action}",
                defaults: new {},
                constraints: new { controller = "MResearch", action = "M02" }
            );

            #endregion

            #region M03
            routes.MapRoute(
                name: "route7",
                url: "V3/{controller}/{x}/{action}",
                defaults: new { controller = "MResearch", action = "M03", x = UrlParameter.Optional },
                constraints: new { controller = "MResearch", action = "M03", x = "|X" }
            );
            #endregion
            //

            routes.MapRoute(
                name: "Cresearch",
                url: "{controller}/{action}",
                defaults: new { controller = "CResearch", action = "C01"},
                constraints: new { controller = "CResearch", action = "C01" }
            );

            routes.MapRoute(
                name: "CResearch2",
                url: "{controller}/{action}",
                defaults: new { controller = "CResearch", action = "C02" },
                constraints: new { controller = "CResearch", action = "C02" }
            );

            routes.MapRoute(
                name: "404",
                url: "{controller}/{action}/{*catchall}",
                defaults: new { controller = "MResearch", action = "MXX" }
            );
        }
    }
}
