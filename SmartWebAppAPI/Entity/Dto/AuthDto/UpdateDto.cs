namespace SmartWebAppAPI.Entity.Dto.AuthDto
{
  public class UpdateDto
  {

    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int UserTypeId { get; set; }
    public int RoleId { get; set; }
  }
}
