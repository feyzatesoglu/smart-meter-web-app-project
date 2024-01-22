using SmartWebAppAPI.Entity.Models;
using System.Linq.Expressions;

namespace SmartWebAppAPI.Repositories
{
  public interface IUserResultRepository : IRepositoryBase<UserResults>
  {
    
    void InsertUserResultByUserId(int userId,string result);
 
    string GetUserResultByUserId(int userId);

    IQueryable<UserResults> GetUserResults();

    List<UserResults> GetUserResultsByUserId(int userId);


    

  }
}
