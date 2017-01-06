using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Monotoring.Startup))]
namespace Monotoring
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
