using Owin;
using System.Configuration;
//using Microsoft.WindowsAzure.ServiceRuntime;

namespace MySample.WebMVC
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseSignInCookies();

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //var foursquareClientId = (RoleEnvironment.IsAvailable) ? RoleEnvironment.GetConfigurationSettingValue("FoursquareClientId") :
            var foursquareClientId = ConfigurationManager.AppSettings.Get("FoursquareClientId");
           // var foursquareClientSecret = (RoleEnvironment.IsAvailable) ? RoleEnvironment.GetConfigurationSettingValue("FoursquareClientSecret") :
            var foursquareClientSecret = ConfigurationManager.AppSettings.Get("FoursquareClientSecret");


            app.UseFoursquareAuthentication(
                clientId : foursquareClientId,
                clientSecret: foursquareClientSecret);

            app.UseGoogleAuthentication();
        }
    }
}