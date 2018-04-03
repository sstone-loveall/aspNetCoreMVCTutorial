using aspNetCoreMVCTutorial.Service;
using aspNetCoreMVCTutorial.ViewModelManagers.Feedback;
using aspNetCoreMVCTutorial.ViewModels.Feedback;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreMVCTutorial.Controllers
{
	public class FeedbackController : Controller
	{
		private readonly IFeedbackService _feedbackService;

		public FeedbackController(IFeedbackService feedbackService)
		{
			_feedbackService = feedbackService;
		}

		public IActionResult Index()
		{
			return RedirectToAction("Feedback");
		}

		public IActionResult Feedback()
		{
			var viewModelMgr = new FeedbackViewModelManager();
			var viewModel = viewModelMgr.BuildViewModel();
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Feedback(FeedbackViewModel feedback)
		{
			if (ModelState.IsValid)
			{
				_feedbackService.AddFeedback(feedback.FeedbackDetails);
				return RedirectToAction("FeedbackComplete");
			}
			return View(feedback);
		}

		public IActionResult FeedbackComplete()
		{
			return View();
		}
	}
}