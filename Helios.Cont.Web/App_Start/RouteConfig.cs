﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Helios.Cont.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Order", action = "NuevaOrden2", id = UrlParameter.Optional }
            //defaults: new { controller = "Dashboard", action = "Dashboardv1", id = UrlParameter.Optional }
            );
        }
    }
}
