using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace speedtest_logger
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //Suitable routes:
            //Home/Index
            //Home/Index/hours/int
            //Home/Index/days/int
            //Home/Index/range/dateTime/dateTime

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{rangeFrom}/{rangeTo}",
                defaults: new { controller = "Home", action = "Index", rangeFrom = UrlParameter.Optional, rangeTo = UrlParameter.Optional }
            );
        }
    }
}
