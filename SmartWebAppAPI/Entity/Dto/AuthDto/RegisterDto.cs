using System.ComponentModel.DataAnnotations;

namespace SmartWebAppAPI.Entity.Dto.AuthDto
{
  public record RegisterDto
  {


    public string? FirstName { get; init; }


    public string? LastName { get; init; }


    public string? Email { get; init; }


    public string? Password { get; init; }

    public string UserType { get; init; }
    public string Role { get; init; }
  }

}

