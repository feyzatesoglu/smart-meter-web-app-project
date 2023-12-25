using SmartWebAppAPI.Entity.Models;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace SmartWebAppAPI.Repositories
{
    public sealed class AuthRepository : RepositoryBase<User>, IAuthRepository
    {
        public AuthRepository(RepositoryContext context) : base(context)
        {
        }

    public void DeleteUser(User user)=>Remove(user);
    

   

    public User? GetOneUserbyEmail(string email, bool trackChanges)
    {
     return FindByCondition(p => p.Email.Equals(email), trackChanges);
    }

    public User? GetOneUserbyId(int id, bool trackChanges)
    {
      return FindByCondition(p => p.Id.Equals(id), trackChanges);
    }

  

    public void Register(User user)=>Add(user);
    public IQueryable<User> GetAllUsers(bool trackChanges) => FindAll(trackChanges);

    public void UpdateOneUser(User user)=>Update(user);

      public IQueryable<User> GetUsersByCondition(Expression<Func<User, bool>> condition)
    {
        return GetAllUsers(false).Where(condition);
    }

    
  }


}
