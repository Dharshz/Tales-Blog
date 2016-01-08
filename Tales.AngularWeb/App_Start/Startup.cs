using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tales.AngularWeb.Infrastructure;
using Tales.Data;

namespace Tales.AngularWeb.App_Start
{
    public partial class Startup
    {

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

       

        public void ConfigureStoreAuthentication(IAppBuilder app)
        {
            // User a single instance of StoreContext and AppStoreUserManager per request
            app.CreatePerOwinContext(BlogEntities.Create);
            app.CreatePerOwinContext<TalesUserManager>(TalesUserManager.Create);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(10),
                AllowInsecureHttp = true
            };

            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}