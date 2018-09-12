using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AmericanService.Startup))]
namespace AmericanService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
