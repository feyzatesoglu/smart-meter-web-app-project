using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SmartWebAppAPI.Entity.Models
{


  public class UserResults
  {
    public int UserResultId { get; set; }
   public int UserId { get; set; }
   public string UserResult { get; set; }

   public DateTime QueryTime { get; set; }


  }

  



}
