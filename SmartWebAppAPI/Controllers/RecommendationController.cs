using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using SmartWebAppAPI.Entity.Dto.Recommendation;
using SmartWebAppAPI.Entity.Models;
using SmartWebAppAPI.Services;
using static SmartWebAppAPI.MLModel;

namespace SmartWebAppAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RecommendationController : ControllerBase
  {
    private readonly IServiceManager _serviceManager;

    public RecommendationController(IServiceManager serviceManager)
    {
      _serviceManager = serviceManager;
    }

    [HttpPost("predict")]
    public IActionResult Post([FromBody] RecommendationRequestDto recommendationRequestDto)
    {

      var result = _serviceManager.RecommendationService.SavePrediction(recommendationRequestDto);
      if (result == null)
      {
        return BadRequest("Prediction failed");
      }
      var data = new { message = result };
      return Ok(data);

    }


    [HttpGet("getprediction/{userId}")]
    public IActionResult GetPrediction(int userId)
    {
      var result = _serviceManager.RecommendationService.GetUserResultsbyId(userId  );
      if (result == null)
      {
        return BadRequest("Prediction failed");
      }

      
      
      return Ok(result);

    }
    

  }
}
