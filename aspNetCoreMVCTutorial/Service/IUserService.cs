using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace aspNetCoreMVCTutorial.Service
{
	public interface IUserService
	{
		IQueryable<IdentityUser> GetUsers();
	}
}