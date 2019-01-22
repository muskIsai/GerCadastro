using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GerApp.Startup))]
namespace GerApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
