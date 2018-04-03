using aspNetCoreMVCTutorial.Domain;

namespace aspNetCoreMVCTutorial.Repository
{
	public interface IFeedbackRepository
	{
		void AddFeedback(Feedback feedback);
	}
}