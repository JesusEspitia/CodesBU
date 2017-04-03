using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CandidateTest.Startup))]
namespace CandidateTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
