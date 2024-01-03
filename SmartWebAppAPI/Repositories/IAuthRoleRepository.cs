using SmartWebAppAPI.Entity.Models;
using System.Linq.Expressions;

namespace SmartWebAppAPI.Repositories
{
  public interface IAuthRoleRepository : IRepositoryBase<UserRole>
  {
    string? GetRoleNameById(int roleId);
    int? GetRoleIdByName(string roleName);
  }
}
