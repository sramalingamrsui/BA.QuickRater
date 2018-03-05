using log4net;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Security
{
	public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthenticator _authenticator;
        private static readonly ILog _logger = LogManager.GetLogger(typeof(SimpleAuthorizationServerProvider));
		private static readonly string _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["RSUIConnectionString"].ConnectionString;

		public SimpleAuthorizationServerProvider(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
			string validationMessage = "";
            bool isValid = _authenticator.AuthenticateUser(context.UserName, context.Password, out validationMessage);

            if (!isValid)
            {
                context.SetError("invalid_grant", validationMessage);
                return;
            }

            var identity = new ClaimsIdentity(context.UserName);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("user_id", context.UserName));

			// get the roles for SecUser
			SecDataContext ctx = new SecDataContext(new SqlConnection(_connStr));
			var roles = ctx.GetRolesForUser(context.UserName, null).ToList();
			roles.ForEach(role => identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName)));

			context.Validated(identity);
        }
    }
}