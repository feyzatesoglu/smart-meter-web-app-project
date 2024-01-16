using Microsoft.ML;
using SmartWebAppAPI.Entity.Dto.Recommendation;
using SmartWebAppAPI.Repositories;
using static SmartWebAppAPI.MLModel;

namespace SmartWebAppAPI.Services
{
  public class RecommendationManager : IRecommendationService
  {


      private readonly IRepositoryManager _manager;

    public RecommendationManager(IRepositoryManager manager)
    {
      _manager = manager;
    }

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


    public string SavePrediction(RecommendationRequestDto recommendationRequestDto)
    {
      try
      {
        var input = new RecommendationDto
      {
        Cografya = recommendationRequestDto.Cografya,
        Mimari = recommendationRequestDto.Mimari,
        Veriİletim = recommendationRequestDto.Veriİletim,
        Yerlesim = recommendationRequestDto.Yerlesim
      };
      var prediction = getPrediction(input);
      if(_manager.QueryCountRepository.GetQueryCountByUserId(recommendationRequestDto.UserId) == 0)
      {
        var message= "Sorgulama Hakkınız bitti";
        return message;
      }
      else
      {
       _manager.UserResultRepository.InsertUserResultByUserId(recommendationRequestDto.UserId, prediction);
      _manager.Save();
      return prediction;
      }
     
      }
      catch (System.Exception)
      {
        
        return null;
      }



      
      
    }
  }
}
