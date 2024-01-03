using SmartWebAppAPI.Entity.Models;
using System.Linq.Expressions;

namespace SmartWebAppAPI.Repositories
{
  public sealed class AuthRoleRepository : RepositoryBase<UserRole>, IAuthRoleRepository
  {
    public AuthRoleRepository(RepositoryContext context) : base(context)
    {


    }

    public int? GetRoleIdByName(string roleName)
    {
      var role = FindByCondition(p => p.RoleName.Equals(roleName), false); // Rol adına göre varlığı getir
      if (role != null)
      {
        return role.RoleId;
      }
      return null;
    }

    public string? GetRoleNameById(int roleId)
    {
      var role = FindByCondition(p => p.RoleId == roleId, false); // Rol ID'sine göre varlığı getir
      if (role != null)
      {
        return role.RoleName;
      }
      return null;
    }


    //getrolenamebyid   

    
  }
}
