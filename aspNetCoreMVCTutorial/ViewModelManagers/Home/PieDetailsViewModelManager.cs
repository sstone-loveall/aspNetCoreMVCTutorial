using aspNetCoreMVCTutorial.Service;
using aspNetCoreMVCTutorial.ViewModels.Home;

namespace aspNetCoreMVCTutorial.ViewModelManagers.Home
{
	public class PieDetailsViewModelManager
	{
		private IPieService _pieService;
		private PieViewModel _viewModel;

		public PieDetailsViewModelManager(IPieService pieService)
		{
			_pieService = pieService;
		}

		public PieViewModel BuildViewModel(PieViewModel viewModel, int pieId)
		{
			_viewModel = viewModel;
			_viewModel.PieDetails = _pieService.GetPieById(pieId);
			_viewModel.Title = _viewModel.PieDetails.Name;
			return _viewModel;
		}
	}
}