using SmartWebAppAPI.Entity.Models;

namespace SmartWebAppAPI.Repositories
{
  public class UserResultsRepository : RepositoryBase<UserResults>, IUserResultRepository
  {
    public UserResultsRepository(RepositoryContext context) : base(context)
    {
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
