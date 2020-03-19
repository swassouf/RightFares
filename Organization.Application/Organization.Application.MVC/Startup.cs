using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Organization.Application.MVC.Startup))]
namespace Organization.Application.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
