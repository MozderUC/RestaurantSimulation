using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RestaurantSimulation.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AddClientOrder",
                url: "restaurant/addClientOrder",
                defaults: new { controller = "Home", action = "AddClientOrder" }
            );
            routes.MapRoute(
                name: "GetClientBill",
                url: "restaurant/getClientBill",
                defaults: new { controller = "Home", action = "GetClientBill" }
            );

            routes.MapRoute(
                name: "AddClients",
                url: "restaurant/addClients",
                defaults: new { controller = "Home", action = "AddClientsService" }
            );

            routes.MapRoute(
                name: "GetClients",
                url: "restaurant/getClients",
                defaults: new { controller = "Home", action = "GetClientsServices" }
            );

            routes.MapRoute(
                name: "GetRestarauntMenu",
                url: "restaurant/getMenu",
                defaults: new { controller = "Home", action = "GetRestarauntMenu" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
