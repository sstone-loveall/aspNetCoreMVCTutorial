using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace aspNetCoreMVCTutorial.Service
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;

		private String errorCode;

		public AuthenticationService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		public Boolean Authenticate(String username, String password)
		{
			Boolean isAuthenticated = false;
			isAuthenticated = doAsyncAuth(username, password).Result;
			return isAuthenticated;
		}

		public Boolean Register(String username, String password)
		{
			Boolean isRegistered = false;
			isRegistered = doAsyncRegistration(username, password).Result;
			Authenticate(username, password);
			return isRegistered;
		}

		public void Logout()
		{
			_signInManager.SignOutAsync();
		}

		public String GetErrorMessage()
		{
			return errorCode;
		}

		private async Task<Boolean> doAsyncAuth(String username, String password)
		{
			var user = await
				_userManager.FindByNameAsync(username);

			if (user != null)
			{
				var result = await
					_signInManager.PasswordSignInAsync(user, password, false, false);

				return result.Succeeded;
			}
			else
			{
				return false;
			}
		}

		private async Task<Boolean> doAsyncRegistration(String username, String password)
		{
			var user = new IdentityUser()
			{
				UserName = username
			};

			var result = await _userManager.CreateAsync(user, password);
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					errorCode = error.Code;
					break;
				}
			}
			return result.Succeeded;
		}
	}
}