using aspNetCoreMVCTutorial.Domain;

namespace aspNetCoreMVCTutorial.Service
{
	public interface IFeedbackService
	{
		void AddFeedback(Feedback feedback);
	}
}