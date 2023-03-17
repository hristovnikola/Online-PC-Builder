using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proekt2.Startup))]
namespace Proekt2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
