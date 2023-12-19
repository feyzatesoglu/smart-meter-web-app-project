using SmartWebAppAPI.Entity.Models;

namespace SmartWebAppAPI.Repositories
{
  public class AuthTypeRepository : RepositoryBase<UserType>, IAuthTypeRepository
  {
    public AuthTypeRepository(RepositoryContext context) : base(context)
    {
    }

    public int? GetTypeIdByName(string typename)
    {
      var role = FindByCondition(p => p.TypeName.Equals(typename), false); // Rol adına göre varlığı getir
      if (role != null)
      {
        return role.UserTypeId;
      }
      return null;
    }
  }
}
