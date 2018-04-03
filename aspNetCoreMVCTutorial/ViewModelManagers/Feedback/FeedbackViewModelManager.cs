using aspNetCoreMVCTutorial.ViewModels.Feedback;

namespace aspNetCoreMVCTutorial.ViewModelManagers.Feedback
{
	public class FeedbackViewModelManager
	{
		private FeedbackViewModel _viewModel;

		public FeedbackViewModelManager()
		{
			_viewModel = new FeedbackViewModel();
		}

		public FeedbackViewModel BuildViewModel()
		{
			setTitle();
			initFeedback();
			return _viewModel;
		}

		private void setTitle()
		{
			_viewModel.Title = "Please send us your feedback";
		}

		private void initFeedback()
		{
			_viewModel.FeedbackDetails = new Domain.Feedback();
		}
	}
}