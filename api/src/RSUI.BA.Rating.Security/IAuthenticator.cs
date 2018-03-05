using System.Threading.Tasks;

namespace RSUI.BA.Rating.Security
{
	public interface IAuthenticator
    {
		bool AuthenticateUser(string userName, string password, out string message);
    }
}