using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSiteMVC.Startup))]
namespace WebSiteMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
