namespace SmartWebAppAPI.Services
{
    public class ServiceManager : IServiceManager
    {

        private readonly IAuthService _authService;
    private readonly IRecommendationService _recommendationService;

    public ServiceManager(IAuthService authService, IRecommendationService recommendationService)
    {
      _authService = authService;
      _recommendationService = recommendationService;
    }

    public IAuthService AuthService => _authService;

    public IRecommendationService RecommendationService => _recommendationService;
  }
}
