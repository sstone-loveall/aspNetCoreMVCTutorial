using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace aspNetCoreMVCTutorial.ViewModels.Admin
{
	public class UserManagementViewModel
	{
		public IQueryable<IdentityUser> Users { get; set; }

		public Boolean NoUsersFound { get; set; }
	}
}