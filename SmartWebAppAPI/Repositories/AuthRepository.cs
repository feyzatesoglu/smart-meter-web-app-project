using SmartWebAppAPI.Entity.Models;
using System.Xml.Linq;

namespace SmartWebAppAPI.Repositories
{
    public sealed class AuthRepository : RepositoryBase<User>, IAuthRepository
    {
        public AuthRepository(RepositoryContext context) : base(context)
        {
        }

   

    public User? GetOneUser(string email, bool trackChanges)
        {
            return FindByCondition(p => p.Email.Equals(email), trackChanges);
        }

   

    public void Register(User user)=>Add(user);
        
    }
}
