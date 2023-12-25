using SmartWebAppAPI.Entity.Models;

namespace SmartWebAppAPI.Repositories
{
  public interface IAuthTypeRepository : IRepositoryBase<UserType>
  {

    int? GetTypeIdByName(string typename);
  }
}
