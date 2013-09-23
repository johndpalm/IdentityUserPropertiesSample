using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySample.WebMVC.Startup))]
namespace MySample.WebMVC
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
