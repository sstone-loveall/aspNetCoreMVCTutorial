using System;
using aspNetCoreMVCTutorial.Domain;
using aspNetCoreMVCTutorial.Repository;

namespace aspNetCoreMVCTutorial.Service.Impl
{
	public class FeedbackService : IFeedbackService
	{
		private IFeedbackRepository _feedbackRepository;
		private bool _isSaved;

		public FeedbackService(IFeedbackRepository feedbackRepository)
		{
			_feedbackRepository = feedbackRepository;
		}

		public void AddFeedback(Feedback feedback)
		{
			_feedbackRepository.AddFeedback(feedback);
			_isSaved = _feedbackRepository.IsSuccess();
		}

		public Boolean IsSuccess()
		{
			return _isSaved;
		}
	}
}