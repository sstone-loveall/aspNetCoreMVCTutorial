using aspNetCoreMVCTutorial.Service;
using aspNetCoreMVCTutorial.ViewModels.Home;

namespace aspNetCoreMVCTutorial.ViewModelManagers.Home
{
	public class PieListViewModelManager
	{
		private IPieService _pieService;
		private PieListViewModel _viewModel;

		public PieListViewModelManager(IPieService pieService)
		{
			_pieService = pieService;
		}

		public PieListViewModel BuildViewModel(PieListViewModel viewModel)
		{
			_viewModel = viewModel;
			_viewModel.Title = "Welcome to the Pie Shop";
			_viewModel.Pies = _pieService.GetAllPies();
			return _viewModel;
		}
	}
}