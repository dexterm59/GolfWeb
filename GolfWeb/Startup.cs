using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GolfWeb.Startup))]
namespace GolfWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
