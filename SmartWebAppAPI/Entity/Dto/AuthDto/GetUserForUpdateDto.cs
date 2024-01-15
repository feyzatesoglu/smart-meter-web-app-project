namespace SmartWebAppAPI.Entity.Dto.AuthDto
{
  public class GetUserForUpdateDto
  {


    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int RoleId { get; set; }
    public int UserTypeId { get; set; }
  }
}
