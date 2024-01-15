using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SmartWebAppAPI.Entity.Models
{


  public class UserResults
  {
    public int UserResultsId { get; set; }
   public int UserId { get; set; }
   public string UserResult { get; set; }

   public string QueryTime { get; set; }


  }

  



}
