using log4net;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Security
{
	public class Authenticator : IAuthenticator
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(Authenticator));

        public Authenticator()
        {
        }

        public bool AuthenticateUser(string userName, string password, out string message)
        {
            bool isValid = false;

            _logger.Debug("Authenticating " + userName);

			using (var ctx = new PrincipalContext(ContextType.Domain, "RSUI"))
			{
				isValid = ctx.ValidateCredentials(userName, password);
				message = isValid ? null : "User Name/Password not found";

				if (!isValid)
				{
					_logger.Debug(userName + " entered an invalid password");
				}
			}

			return isValid;
        }
    }
}