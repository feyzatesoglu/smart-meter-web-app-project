using SmartWebAppAPI.Entity.Models;
using System.Linq.Expressions;

namespace SmartWebAppAPI.Repositories
{
  public interface IAuthRoleRepository : IRepositoryBase<UserRole>
  {

    int? GetRoleIdByName(string roleName);
  }
}
