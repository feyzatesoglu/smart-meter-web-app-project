using Microsoft.ML;
using SmartWebAppAPI.Entity.Dto.Recommendation;
using static SmartWebAppAPI.MLModel;

namespace SmartWebAppAPI.Services
{
  public class RecommendationManager : IRecommendationService
  {
    public string getPrediction(RecommendationDto recommendationDto)
    {
      string modelPath = Path.GetFullPath("MLModel.mlnet");
      var mlContext = new MLContext();
      ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelSchema);
      var prediction = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

      var input = new ModelInput
      {
        Co_rafya = recommendationDto.Cografya,
        Bina_Mimari = recommendationDto.Mimari,
        Veri_Density = recommendationDto.Veriİletim,
        Yerle_im_Plan_ = recommendationDto.Yerlesim
      };

      var predictionResult = prediction.Predict(input);
      return predictionResult.PredictedLabel;
    }
  }
}
