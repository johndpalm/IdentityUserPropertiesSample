using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySample.Web.MVC.Startup))]
namespace MySample.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
