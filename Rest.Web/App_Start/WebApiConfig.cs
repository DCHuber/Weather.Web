using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Weather.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Weather",
                routeTemplate: "api/weather/{id}",
                defaults: new { controller = "weather", id = RouteParameter.Optional }

            );
        }
    }
}
