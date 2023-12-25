using SmartWebAppAPI.Entity.Dto.Recommendation;
using static SmartWebAppAPI.MLModel;

namespace SmartWebAppAPI.Services
{
  public interface IRecommendationService
  {
    string getPrediction(RecommendationDto recommendationDto);
  }
}
