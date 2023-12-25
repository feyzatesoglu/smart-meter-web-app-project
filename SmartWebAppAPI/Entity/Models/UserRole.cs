namespace SmartWebAppAPI.Entity.Models
{
  public class UserRole
  {
    public int RoleId { get; set; }
    public string? RoleName { get; set; }

    public ICollection<User>? Users { get; set; } // UserRole'a ait kullanıcılar
  }
}
