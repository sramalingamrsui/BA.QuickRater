using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace RSUI.BA.Rating.Security
{
	public class Configuration
	{
		public static void ConfigureOAuth(IAppBuilder app, string tokenEndpointPath, int tokenExpireTimeSpan = 90)
		{
			//app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			var opts = new OAuthAuthorizationServerOptions
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString(tokenEndpointPath),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(tokenExpireTimeSpan),
				Provider = new SimpleAuthorizationServerProvider(new Authenticator())
			};

			app.UseOAuthAuthorizationServer(opts);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}
