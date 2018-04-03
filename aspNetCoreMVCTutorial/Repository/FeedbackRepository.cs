using System;
using aspNetCoreMVCTutorial.Domain;
using aspNetCoreMVCTutorial.Repository.EntityFramework;

namespace aspNetCoreMVCTutorial.Repository
{
	public class FeedbackRepository : IFeedbackRepository
	{
		private readonly AppDbContext _appDbContext;
		private bool _isSaved;

		public FeedbackRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public Boolean IsSuccess()
		{
			return _isSaved;
		}

		public void AddFeedback(Feedback feedback)
		{
			var result = _appDbContext.Feedbacks.Add(feedback);
			int numSaved = _appDbContext.SaveChanges();
			_isSaved = numSaved > 0;
		}
	}
}
