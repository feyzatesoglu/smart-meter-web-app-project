using Microsoft.ML;

using Moq;
using NUnit.Framework;
using SmartWebAppAPI.Entity.Dto.Recommendation;
using SmartWebAppAPI.Repositories;
using SmartWebAppAPI.Services;

namespace SmartWebAppAPI.Tests.Services
{
  [TestFixture]
  public class RecommendationManagerTests
  {
    [Test]
    public void SavePrediction_ShouldSavePrediction_WhenQueryCountIsGreaterThanZero()
    {
      // Arrange
      var mockRepositoryManager = new Mock<IRepositoryManager>();
      var mockQueryCountRepository = new Mock<IQueryCountRepository>();


      // Assuming _manager.QueryCountRepository is used in the original class
      mockRepositoryManager.Setup(manager => manager.QueryCountRepository).Returns(mockQueryCountRepository.Object);

      var recommendationManager = new RecommendationManager(mockRepositoryManager.Object);

      var recommendationRequestDto = new RecommendationRequestDto
      {
        UserId = 123,
        Cografya = 1.5f, // Assuming Cografya is a float property
        Mimari = 2.0f,  // Assuming Mimari is a float property
        Veriİletim = 3.5f, // Assuming Veriİletim is a float property
        Yerlesim = 4.2f //
      };

      var recommendationDto = new RecommendationDto
      {
    
        Cografya = 1.5f, // Assuming Cografya is a float property
        Mimari = 2.0f,  // Assuming Mimari is a float property
        Veriİletim = 3.5f, // Assuming Veriİletim is a float property
        Yerlesim = 4.2f //
      };

      var mockPrediction = "Lan";

      mockQueryCountRepository.Setup(repo => repo.GetQueryCountByUserId(recommendationRequestDto.UserId)).Returns(1);

      mockRepositoryManager.Setup(manager => manager.UserResultRepository)
                           .Returns(Mock.Of<IUserResultRepository>());

      mockRepositoryManager.Setup(manager => manager.Save());

      // Act
      var result = recommendationManager.SavePrediction(recommendationRequestDto);

      // Assert
      Assert.AreEqual(mockPrediction, result);
      mockRepositoryManager.Verify(manager => manager.UserResultRepository.InsertUserResultByUserId(recommendationRequestDto.UserId, mockPrediction), Times.Once);
      mockRepositoryManager.Verify(manager => manager.Save(), Times.Once);
    }

    [Test]
    public void SavePrediction_WithNoQueryCount_ReturnsQueryLimitReachedMessage()
    {
      // Arrange
      var recommendationRequestDto = new RecommendationRequestDto
      {
        
        UserId = 123,
        Cografya = 1.5f, // Assuming Cografya is a float property
        Mimari = 2.0f,  // Assuming Mimari is a float property
        Veriİletim = 3.5f, // Assuming Veriİletim is a float property
        Yerlesim = 4.2f //
      };

      // Mock the repository manager
      var repositoryManagerMock = new Mock<IRepositoryManager>();
      repositoryManagerMock.Setup(x => x.QueryCountRepository.GetQueryCountByUserId(It.IsAny<int>()))
                            .Returns(0); // Assume there is no query count for the user

      var recommendationManager = new RecommendationManager(repositoryManagerMock.Object);

      // Act
      var result = recommendationManager.SavePrediction(recommendationRequestDto);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual("Sorgulama Hakkınız bitti", result);
    }

    [Test]
    public void SavePrediction_WithException_ReturnsNull()
    {
      // Arrange
      var recommendationRequestDto = new RecommendationRequestDto
      {
        UserId = 123,
        Cografya = 1.5f, // Assuming Cografya is a float property
        Mimari = 2.0f,  // Assuming Mimari is a float property
        Veriİletim = 3.5f, // Assuming Veriİletim is a float property
        Yerlesim = 4.2f //
      };

      // Mock the repository manager to throw an exception
      var repositoryManagerMock = new Mock<IRepositoryManager>();
      repositoryManagerMock.Setup(x => x.QueryCountRepository.GetQueryCountByUserId(It.IsAny<int>()))
                            .Throws(new System.Exception("Some exception message"));

      var recommendationManager = new RecommendationManager(repositoryManagerMock.Object);

      // Act
      var result = recommendationManager.SavePrediction(recommendationRequestDto);

      // Assert
      Assert.IsNull(result);
    }
  }
}
