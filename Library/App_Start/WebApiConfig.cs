using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Ninject;
using Ninject.Infrastructure;
using Ninject.Extensions.ChildKernel;
using Library.Models;
using Library.Controllers;

using Microsoft.Extensions.DependencyInjection;

namespace Library
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
