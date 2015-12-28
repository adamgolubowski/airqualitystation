using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(station.Startup))]
namespace station
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
