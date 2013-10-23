using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Configuration;
using System.Threading.Tasks;

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
                var msaccountOptions = new Microsoft.Owin.Security.MicrosoftAccount.MicrosoftAccountAuthenticationOptions()
                {
                    ClientId = ConfigurationManager.AppSettings.Get("MicrosoftClientId"),
                    ClientSecret = ConfigurationManager.AppSettings.Get("MicrosoftClientSecret"),
                    Provider = new Microsoft.Owin.Security.MicrosoftAccount.MicrosoftAccountAuthenticationProvider()
                    {
                        OnAuthenticated = (context) =>
                            {
                                context.Identity.AddClaim(new System.Security.Claims.Claim("urn:microsoftaccount:access_token", context.AccessToken, XmlSchemaString, "Microsoft"));

                                // The code below isn't working.  Issue here: https://katanaproject.codeplex.com/workitem/145
                                //foreach (var x in context.User)
                                //{
                                //    var claimType = string.Format("urn:microsoftaccount:{0}", x.Key);
                                //    string claimValue = x.Value.ToString();
                                //    if (!context.Identity.HasClaim(claimType, claimValue))
                                //        context.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, XmlSchemaString, "Microsoft"));
                                //}

                                return Task.FromResult(0);
                            }
                    }
                };

                app.UseMicrosoftAccountAuthentication(msaccountOptions);
            }

            // Twitter : Create a new application
            // https://dev.twitter.com/apps
            if (ConfigurationManager.AppSettings.Get("TwitterConsumerKey").Length > 0)
            {
                var twitterOptions = new Microsoft.Owin.Security.Twitter.TwitterAuthenticationOptions()
                {
                    ConsumerKey = ConfigurationManager.AppSettings.Get("TwitterConsumerKey"),
                    ConsumerSecret = ConfigurationManager.AppSettings.Get("TwitterConsumerSecret"),
                    Provider = new Microsoft.Owin.Security.Twitter.TwitterAuthenticationProvider()
                    {
                        OnAuthenticated = (context) =>
                            {
                                context.Identity.AddClaim(new System.Security.Claims.Claim("urn:twitter:access_token", context.AccessToken, XmlSchemaString, "Twitter"));
                                return Task.FromResult(0);
                            }
                    }
                };

                app.UseTwitterAuthentication(twitterOptions);
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
                                context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:access_token", context.AccessToken, XmlSchemaString, "Facebook"));
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
                            context.Identity.AddClaim(new System.Security.Claims.Claim("urn:foursquare:access_token", context.AccessToken, XmlSchemaString, "Foursquare"));

                            // Same issue as MicrosoftAccount auth provider (same core codeset) https://katanaproject.codeplex.com/workitem/145
                            //foreach (var x in context.User)
                            //{
                            //    var claimType = string.Format("urn:foursquare:{0}", x.Key);
                            //    string claimValue = x.Value.ToString();
                            //    if (!context.Identity.HasClaim(claimType, claimValue))
                            //        context.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, XmlSchemaString, "Foursquare"));
                            //}

                            return Task.FromResult(0);
                        }
                    }
                };

                app.UseFoursquareAuthentication(foursquareOptions);

            }

            // Google : nothing to do here.
            app.UseGoogleAuthentication();
        }

        const string XmlSchemaString = "http://www.w3.org/2001/XMLSchema#string";
        const string ignoreClaimPrefix = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims";

    }
}