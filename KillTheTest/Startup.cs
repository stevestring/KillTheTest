using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KillTheTest.Startup))]
namespace KillTheTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
