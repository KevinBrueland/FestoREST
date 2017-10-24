using Owin;

[assembly: Microsoft.Owin.OwinStartup(typeof(Festo.API.Startup))]

namespace Festo.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {           
            app.UseWebApi(WebApiConfig.Register());
            
        }
    }
}