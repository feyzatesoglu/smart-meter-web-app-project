using SmartWebAppAPI.Entity.Models;
using System.Linq.Expressions;

namespace SmartWebAppAPI.Repositories
{
  public interface IQueryCountRepository : IRepositoryBase<QueryCount>
  {
    int GetQueryCountByUserId(int userId);
    void UpdateQueryCountByUserId(int userId);

    void InsertQueryCountByUserId(int userId,string userType);

    void UpdateQueryCountByUserIdUserType(int userId,string userType);
  

   
  


  }
}
