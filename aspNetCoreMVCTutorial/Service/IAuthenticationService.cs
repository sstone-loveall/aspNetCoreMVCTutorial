using System;
using System.Threading.Tasks;

namespace aspNetCoreMVCTutorial.Service
{
	public interface IAuthenticationService
	{
		Boolean Authenticate(String username, String password);

		Boolean Register(String username, String password);

		void Logout();

		String GetErrorMessage();
	}
}