using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Casino.AdminPortal.Web.Startup))]
namespace Casino.AdminPortal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
