using aspNetCoreMVCTutorial.Domain;
using aspNetCoreMVCTutorial.Repository;
using aspNetCoreMVCTutorial.Service.Impl;
using Moq;
using NUnit.Framework;

namespace aspNetCoreMVCTutorial.Tests.Service
{
	[TestFixture]
	public class FeedbackServiceTest
	{
		public class TestSetup
		{
			public FeedbackService SetupFeedbackService()
			{
				var mockFeedbackRepo = new Mock<IFeedbackRepository>();
				return new FeedbackService(mockFeedbackRepo.Object);
			}
		}

		[Test]
		public void AddFeedback_FeedbackNotSaved_IsNotSuccess()
		{
			// Arrange
			var service = new TestSetup().SetupFeedbackService();

			// Act
			var feedback = new Feedback();
			service.AddFeedback(feedback);
			var actualSuccess = service.IsSuccess();

			// Assert
			Assert.IsFalse(actualSuccess);
		}
	}
}