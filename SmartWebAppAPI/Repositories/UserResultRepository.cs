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

    public IQueryable<UserResults> GetUserResults()
{
  
    return FindAll(false);
}

public IQueryable<UserResults> GetUserResultsbyId(int userId)
{
    // Burada direkt olarak sorguyu dönebilirsiniz.
    return GetUserResults().Where(x => x.UserId == userId);
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
