using SmartWebAppAPI.Entity.Dto.Recommendation;
using SmartWebAppAPI.Entity.Models;
using static SmartWebAppAPI.MLModel;

namespace SmartWebAppAPI.Services
{
  public interface IRecommendationService
  {
    string getPrediction(RecommendationDto recommendationDto);
    string SavePrediction(RecommendationRequestDto recommendationRequestDto);
   List<UserResults> GetUserResultsbyId(int userId);
  }
}
