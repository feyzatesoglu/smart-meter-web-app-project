using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartWebAppAPI.Entity.Models
{


  public class QueryCount
  {

   public int QueryCountId { get; set; }

    public int UserId { get; set; }
    public int Count { get; set; }

   
   

  }

  



}
