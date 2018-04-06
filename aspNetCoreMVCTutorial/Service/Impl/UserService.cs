using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace aspNetCoreMVCTutorial.Service.Impl
{
	public class UserService : IUserService
	{
		private UserManager<IdentityUser> _userManager;

		public UserService(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		public IQueryable<IdentityUser> GetUsers()
		{
			return _userManager.Users;
		}
	}
}