using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace WebApplication1
{
    public partial class Startup
    {
        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions authorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(authorizationServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private class CustomAuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                await Task.Run(() => { context.Validated(); });                   
            }

            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                await Task.Run(()=> 
                {
                    context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                    AuthRepository authrepository = new AuthRepository();
                    bool isValid = authrepository.ValidateUser(context.UserName, context.Password);

                    if (!isValid)
                    {
                        context.SetError("invalid_grant", "The user name or password is incorrect.");
                    }

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

                    context.Validated(identity);
                });
            }

            private class AuthRepository
            {
                public AuthRepository()
                {
                }

                public bool ValidateUser(string userName, string password)
                {
                    // Connection to DataBase
                    return true;
                }
            }
        }
    }
}