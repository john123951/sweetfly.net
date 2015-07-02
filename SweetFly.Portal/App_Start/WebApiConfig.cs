using SweetFly.Interceptors.DelegatingHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace SweetFly.Portal
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //首页
            //config.Routes.MapHttpRoute(
            //     "Home",
            //     "",
            //     new { controller = "Test", action = "Test", httpMethod = new HttpMethodConstraint("GET") });

            //注册路由
            config.Routes.MapHttpRoute(
                 "Normal",
                 "api/{controller}/{action}/{id}",
                 new { id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint("GET", "PUT", "DELETE", "POST") });

        }
    }
}
