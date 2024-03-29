﻿using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace fannexApi
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
      config.EnableCors(cors);

      config.Formatters.JsonFormatter.SupportedMediaTypes
      .Add(new MediaTypeHeaderValue("text/html"));
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
