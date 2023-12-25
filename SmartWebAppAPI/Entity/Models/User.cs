using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SmartWebAppAPI.Entity.Models
{


  public class User
  {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public DateTime? CreatedDate { get; set; }


    public UserType? UserType { get; set; }
    public int UserTypeId{ get; set; }
    public UserRole? Role { get; set; }
    public int? RoleId { get; set; }

  }

  



}
