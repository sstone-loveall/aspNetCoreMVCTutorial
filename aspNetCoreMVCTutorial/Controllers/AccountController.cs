using aspNetCoreMVCTutorial.Service;
using aspNetCoreMVCTutorial.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreMVCTutorial.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAuthenticationService _authenticationService;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;

		public AccountController(
			IAuthenticationService authenticationService,
			SignInManager<IdentityUser> signInManager,
			UserManager<IdentityUser> userManager)
		{
			_authenticationService = authenticationService;
			_signInManager = signInManager;
			_userManager = userManager;
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}
			else if (_authenticationService.Authenticate(viewModel.Username, viewModel.Password))
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				viewModel.ErrorMessage = _authenticationService.GetErrorMessage();
			}

			ModelState.AddModelError("", "Username/password not found");
			return View(viewModel);
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(LoginViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				if (_authenticationService.Register(viewModel.Username, viewModel.Password))
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					viewModel.ErrorMessage = _authenticationService.GetErrorMessage();
				}
			}

			return View(viewModel);
		}

		[Authorize]
		public IActionResult Logout()
		{
			_authenticationService.Logout();
			return RedirectToAction("Index", "Home");
		}
	}
}