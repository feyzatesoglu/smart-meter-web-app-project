using SmartWebAppAPI.Entity.Models;
using System.Linq.Expressions;

namespace SmartWebAppAPI.Repositories
{
  public sealed class QueryCountRepository : RepositoryBase<QueryCount>, IQueryCountRepository
  {
    public QueryCountRepository(RepositoryContext context) : base(context)
    {
    }

    public int GetQueryCountByUserId(int userId)
    {
      
        var queryCount = FindByCondition(p => p.UserId == userId, false); // Rol adına göre varlığı getir
        if (queryCount != null)
        {
            return queryCount.Count;
        }
        return 0;
    }

    public void InsertQueryCountByUserId(int userId, string userType)
    {
        var queryCount = FindByCondition(p => p.UserId == userId,false); // Rol adına göre varlığı getir
        if (queryCount == null)
        {
            var newQueryCount = new QueryCount();
            newQueryCount.UserId = userId;
            if (userType == "Ücretsiz")
            {
                newQueryCount.Count = 5;
            }
            else if (userType == "Normal")
            {
                newQueryCount.Count = 50;
            }
            else
            {
                newQueryCount.Count = 100;
            }
           
            Add(newQueryCount);
        }
     

    }

  

    public void UpdateQueryCountByUserId(int userId)
    {
        var queryCount = FindByCondition(p => p.UserId == userId, false); // Rol adına göre varlığı getir
        if (queryCount != null)
        {
            queryCount.Count= queryCount.Count - 1;
            Update(queryCount);
        }
    }
  }
}
