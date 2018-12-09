using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(RestaurantSimulation.WEB.Startup))]

namespace RestaurantSimulation.WEB
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}