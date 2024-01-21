using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SmartWebAppAPI.Controllers;
using SmartWebAppAPI.Entity.Dto.Recommendation;
using SmartWebAppAPI.Services;

namespace SmartWebAppAPI.Tests.Controllers
{
  [TestFixture]
  public class RecommendationControllerTests
  {
    [Test]
    public void Post_WithValidData_ReturnsOk()
    {
      // Arrange
      var recommendationRequestDto = new RecommendationRequestDto(); // Provide valid data for the test

      // Mock the service manager
      var serviceManagerMock = new Mock<IServiceManager>();
      serviceManagerMock.Setup(x => x.RecommendationService.SavePrediction(It.IsAny<RecommendationRequestDto>()))
                        .Returns("Prediction Result"); // Set up the expected result

      var controller = new RecommendationController(serviceManagerMock.Object);

      // Act
      var result = controller.Post(recommendationRequestDto) as OkObjectResult;

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(200, result.StatusCode);
      Assert.IsNotNull(result.Value);
      Assert.AreEqual("Prediction Result", result.Value.GetType().GetProperty("message").GetValue(result.Value));
    }

    [Test]
    public void Post_WithInvalidData_ReturnsBadRequest()
    {
      // Arrange
      var recommendationRequestDto = new RecommendationRequestDto(); // Provide invalid data for the test

      // Mock the service manager
      var serviceManagerMock = new Mock<IServiceManager>();
      serviceManagerMock.Setup(x => x.RecommendationService.SavePrediction(It.IsAny<RecommendationRequestDto>()))
                        .Returns((string)null); // Set up the expected result for failure

      var controller = new RecommendationController(serviceManagerMock.Object);

      // Act
      var result = controller.Post(recommendationRequestDto) as BadRequestObjectResult;

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(400, result.StatusCode);
      Assert.AreEqual("Prediction failed", result.Value);
    }
  }
}
