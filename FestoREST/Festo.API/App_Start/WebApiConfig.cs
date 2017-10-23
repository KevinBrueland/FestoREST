using Festo.API.Resolver;
using Festo.Common.DataMapperInterfaces;
using Festo.Common.RepositoryInterfaces;
using Festo.DataAccess.ConcreteRepositories;
using Festo.Utility.DataMappers;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace Festo.API
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var container = new UnityContainer();
            container.LoadRegistries();
            
            var config = new HttpConfiguration();
            
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultRouting",
                routeTemplate: "api/{controller}/{id}/{id1}",
                defaults: new { id = RouteParameter.Optional, id1 = RouteParameter.Optional });

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json-patch+json"));

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            

            return config;
        }
    }
}
