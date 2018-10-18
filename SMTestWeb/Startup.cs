using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMTestWeb.Startup))]
namespace SMTestWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
