using SmartWebAppAPI.Entity.Models;
using System.Linq.Expressions;

namespace SmartWebAppAPI.Repositories
{
  public interface IAuthRepository : IRepositoryBase<User>
  {
    void Register(User user);
    User? GetOneUserbyEmail(string email, bool trackChanges);
    User? GetOneUserbyId(int id, bool trackChanges);
    void DeleteUser(User user);
    IQueryable<User> GetAllUsers(bool trackChanges);
    void UpdateOneUser(User user);
     IQueryable<User> GetUsersByCondition(Expression<Func<User, bool>> condition);
  }
}
