using Owin;
using System.Configuration;

namespace MySample.WebMVC
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseSignInCookies();

            // Microsoft : Create application
            // https://account.live.com/developers/applications
            if (ConfigurationManager.AppSettings.Get("MicrosoftClientId").Length > 0)
            {
                app.UseMicrosoftAccountAuthentication(
                    clientId: ConfigurationManager.AppSettings.Get("MicrosoftClientId"),
                    clientSecret: ConfigurationManager.AppSettings.Get("MicrosoftClientSecret"));
            }

            // Twitter : Create a new application
            // https://dev.twitter.com/apps
            if (ConfigurationManager.AppSettings.Get("TwitterConsumerKey").Length > 0)
            {
                app.UseTwitterAuthentication(
                   consumerKey: ConfigurationManager.AppSettings.Get("TwitterConsumerKey"),
                   consumerSecret: ConfigurationManager.AppSettings.Get("TwitterConsumerSecret"));
            }

            // Facebook : Create New App
            // https://dev.twitter.com/apps
            if (ConfigurationManager.AppSettings.Get("FacebookAppId").Length > 0)
            {
                app.UseFacebookAuthentication(
                   appId: ConfigurationManager.AppSettings.Get("FacebookAppId"),
                   appSecret: ConfigurationManager.AppSettings.Get("FacebookAppSecret"));
            }

            // Foursquare : Create a new app
            // https://foursquare.com/developers/apps
            if (ConfigurationManager.AppSettings.Get("FoursquareClientId").Length > 0)
            {
                app.UseFoursquareAuthentication(
                    clientId: ConfigurationManager.AppSettings.Get("FoursquareClientId"),
                    clientSecret: ConfigurationManager.AppSettings.Get("FoursquareClientSecret"));
            }

            // Google : nothing to do here.
            app.UseGoogleAuthentication();
        }
    }
}