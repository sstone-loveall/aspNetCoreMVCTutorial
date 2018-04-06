using System.Linq;
using aspNetCoreMVCTutorial.Service;
using aspNetCoreMVCTutorial.ViewModels.Admin;

namespace aspNetCoreMVCTutorial.ViewModelManagers.Admin
{
	public class UserManagementViewModelManager
	{
		private UserManagementViewModel _viewModel;
		private IUserService _userService;

		public UserManagementViewModelManager(IUserService userService)
		{
			_viewModel = new UserManagementViewModel();
		}

		public UserManagementViewModel BuildViewModel()
		{
			populateUsers();
			_viewModel.NoUsersFound = !determineIfUsersExist();
			return _viewModel;
		}

		private void populateUsers()
		{
			_viewModel.Users = _userService.GetUsers();
		}

		private bool determineIfUsersExist()
		{
			return _viewModel.Users.Any();
		}
	}
}