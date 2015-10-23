using System;
using System.Web.Http;
using Newtonsoft.Json;

namespace PD.CLI.CORE.Server {

    public static class GlobalConfiguration {

        private static readonly Lazy<HttpConfiguration> HttpConfigurationLazy = new Lazy<HttpConfiguration>( BuildConfiguration );
        public static HttpConfiguration HttpConfiguration => HttpConfigurationLazy.Value;

        private static HttpConfiguration BuildConfiguration() {
            var config = new HttpConfiguration {
                Formatters = {
                    JsonFormatter = {
                        SerializerSettings = {
                            Formatting = Formatting.Indented
                        }
                    }
                }
            };
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute( name: "DefaultApi", routeTemplate: "{controller}/{id}/{action}", defaults: new { id = RouteParameter.Optional } );
            
            return config;
        }

    }

}