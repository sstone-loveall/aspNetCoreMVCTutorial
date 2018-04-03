using aspNetCoreMVCTutorial.Service;
using aspNetCoreMVCTutorial.ViewModelManagers.Home;
using aspNetCoreMVCTutorial.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreMVCTutorial.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPieService _pieService;

		public HomeController(IPieService pieService)
		{
			// this ctor is an example of constructor injection
			_pieService = pieService;
		}

		public IActionResult Index()
		{
			var viewModel = new PieListViewModel();
			var viewModelMgr = new PieListViewModelManager(_pieService);
			viewModel = viewModelMgr.BuildViewModel(viewModel);
			return View(viewModel);
		}

		public IActionResult Details(int id)
		{
			var viewModel = new PieViewModel();
			var viewModelMgr = new PieDetailsViewModelManager(_pieService);
			viewModel = viewModelMgr.BuildViewModel(viewModel, id);
			return View(viewModel);
		}
	}
}