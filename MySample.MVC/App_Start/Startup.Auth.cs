using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Configuration;

namespace MySample.MVC
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

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