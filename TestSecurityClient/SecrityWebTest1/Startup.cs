using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecrityWebTest1.Startup))]
namespace SecrityWebTest1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
