using aspNetCoreMVCTutorial.Service;
using aspNetCoreMVCTutorial.ViewModelManagers.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreMVCTutorial.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		private IUserService _userService;

		public AdminController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult UserManagement()
		{
			var viewModelMgr = new UserManagementViewModelManager(_userService);
			var viewModel = viewModelMgr.BuildViewModel();
			return View(viewModel);
		}
	}
}