namespace SmartWebAppAPI.Services
{
    public interface IServiceManager
    {
        IAuthService AuthService { get; }
    IRecommendationService RecommendationService { get; }
    
  }
}