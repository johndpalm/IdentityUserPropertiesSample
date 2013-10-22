using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Configuration;
using System.Threading.Tasks;

namespace MySample.Web.MVC
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
                var facebookOptions = new Microsoft.Owin.Security.Facebook.FacebookAuthenticationOptions()
                {
                    AppId = ConfigurationManager.AppSettings.Get("FacebookAppId"),
                    AppSecret = ConfigurationManager.AppSettings.Get("FacebookAppSecret"),
                    Provider = new Microsoft.Owin.Security.Facebook.FacebookAuthenticationProvider()
                    {
                        OnAuthenticated = (context) =>
                        {
                            const string XmlSchemaString = "http://www.w3.org/2001/XMLSchema#string";
                            foreach (var x in context.User)
                            {
                                var claimType = string.Format("urn:facebook:{0}", x.Key);
                                string claimValue = x.Value.ToString();
                                if (!context.Identity.HasClaim(claimType, claimValue))
                                    context.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, XmlSchemaString, "Facebook"));

                            }
                            return Task.FromResult(0);
                        }
                    }

                };

                facebookOptions.Scope.Add("email");

                app.UseFacebookAuthentication(facebookOptions);
            }


            // Foursquare : Create a new app
            // https://foursquare.com/developers/apps
            if (ConfigurationManager.AppSettings.Get("FoursquareClientId").Length > 0)
            {
                var foursquareOptions = new Citrius.Owin.Security.Foursquare.FoursquareAuthenticationOptions()
                {
                    ClientId = ConfigurationManager.AppSettings.Get("FoursquareClientId"),
                    ClientSecret = ConfigurationManager.AppSettings.Get("FoursquareClientSecret"),
                    Provider = new Citrius.Owin.Security.Foursquare.FoursquareAuthenticationProvider()
                    {
                        OnAuthenticated = context =>
                        {
                            const string XmlSchemaString = "http://www.w3.org/2001/XMLSchema#string";
                            foreach (var x in context.User)
                            {
                                var claimType = string.Format("urn:foursquare:{0}", x.Key);
                                string claimValue = x.Value.ToString();
                                if (!context.Identity.HasClaim(claimType, claimValue))
                                    context.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, XmlSchemaString, "Foursquare"));

                            }

                            return Task.FromResult(0);
                        }
                    }
                };

                app.UseFoursquareAuthentication(foursquareOptions);
            }

            // Google : nothing to do here.
            app.UseGoogleAuthentication();
        }
    }
}