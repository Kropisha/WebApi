// <copyright file="WebApiConfig.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Configuration
{
    using System.Web.Http;

    /// <summary>
    /// Configuration class
    /// </summary>
    public class WebApiConfig
    {
        /// <summary>
        /// Get specified route
        /// </summary>
        /// <param name="config">configuration instance</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}