

using System.Linq.Expressions;

namespace SmartWebAppAPI.Repositories
{
    public interface IRepositoryBase<T>
    {




        void Add(T entity);
         T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

  


  }
}
