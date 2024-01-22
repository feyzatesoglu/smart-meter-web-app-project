using Microsoft.Data.SqlClient;


using Microsoft.EntityFrameworkCore;
using SmartWebAppAPI.Entity.Models;

namespace SmartWebAppAPI.Repositories
{
  public class UserResultsRepository : RepositoryBase<UserResults>, IUserResultRepository
  {
    public UserResultsRepository(RepositoryContext context) : base(context)
    {
    }


   
    public List<UserResults> GetUserResultsByUserId(int userId)
    {
        var parameters = new[]
        {
            new SqlParameter("@UserId", userId)
        };

        return _context.UserResults
            .FromSqlRaw("EXEC GetUserResultsByUserId @UserId", parameters)
            .ToList();
    }


    public string GetUserResultByUserId(int userId)
    {
        var userResult = FindByCondition(x => x.UserId == userId,false);
        if (userResult != null)
        {
            return userResult.UserResult;
        }
        else
        {
            return null;
        }
    }

    public IQueryable<UserResults> GetUserResults()
{
  
    return FindAll(false);
}

  



    

    public void InsertUserResultByUserId(int userId, string result)
    {

        var userResult = new UserResults
        {
            UserId = userId,
            UserResult = result,
            QueryTime = DateTime.Now

        };
        Add(userResult);
      
     

    }

 
  }
}
