

using System.Linq.Expressions;

namespace SmartWebAppAPI.Repositories
{
    public interface IRepositoryBase<T>
    {




        void Add(T entity);


        public T? FindById(Expression<Func<T, bool>> expression, bool trackChanges);

        public T? FindByEmail(Expression<Func<T, bool>> expression, bool trackChanges);
       


    }
}
