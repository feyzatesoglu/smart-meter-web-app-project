using SmartWebAppAPI.Entity.Models;
using System.Linq.Expressions;

namespace SmartWebAppAPI.Repositories
{
    public interface IAuthRepository :IRepositoryBase<User>
    {

        void Register(User user);
        User? GetOneUser(string email, bool trackChanges);


    }
}
