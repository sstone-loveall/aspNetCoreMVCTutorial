using aspNetCoreMVCTutorial.Domain;
using aspNetCoreMVCTutorial.Repository;

namespace aspNetCoreMVCTutorial.Service
{
	public class FeedbackService : IFeedbackService
	{
		private IFeedbackRepository _feedbackRepository;

		public FeedbackService(IFeedbackRepository feedbackRepository)
		{
			_feedbackRepository = feedbackRepository;
		}

		public void AddFeedback(Feedback feedback)
		{
			_feedbackRepository.AddFeedback(feedback);
		}
	}
}