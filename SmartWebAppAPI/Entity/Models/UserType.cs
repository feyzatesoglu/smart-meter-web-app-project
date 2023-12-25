namespace SmartWebAppAPI.Entity.Models
{


  

    public class UserType
    {
      public int UserTypeId { get; set; }
      public string? TypeName { get; set; }

      public ICollection<User>? Users { get; set; } // UserType'a ait kullanıcılar
    }
  
}
