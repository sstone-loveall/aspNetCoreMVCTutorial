using System;

namespace aspNetCoreMVCTutorial.ViewModels.Feedback
{
    public class FeedbackViewModel
    {
		public String Title { get; set; }

		public aspNetCoreMVCTutorial.Domain.Feedback FeedbackDetails { get; set; }
    }
}
