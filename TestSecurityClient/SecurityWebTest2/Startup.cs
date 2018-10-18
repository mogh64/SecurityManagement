using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecurityWebTest2.Startup))]
namespace SecurityWebTest2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
