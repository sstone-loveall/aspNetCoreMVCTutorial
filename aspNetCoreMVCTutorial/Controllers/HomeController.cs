using System.Linq;
using aspNetCoreMVCTutorial.Service;
using aspNetCoreMVCTutorial.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspNetCoreMVCTutorial.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPieService _pieService;

		// constructor injection
		public HomeController(IPieService pieService)
		{
			_pieService = pieService;
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			var pies = _pieService.GetAllPies().OrderBy(p => p.Name);
			var viewModel = new HomeViewModel()
			{
				Title = "Welcome to Bethany's Pie Shop",
				Pies = pies.ToList()
			};

			return View(viewModel);
		}
	}
}