using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySample.MVC.Startup))]
namespace MySample.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
