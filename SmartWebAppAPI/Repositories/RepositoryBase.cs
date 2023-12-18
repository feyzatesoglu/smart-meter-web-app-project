



using System.Data.Entity;
using System.Linq.Expressions;

namespace SmartWebAppAPI.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class,new()
    {

        protected readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T? FindById(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>().Where(expression).SingleOrDefault()
                : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }
        public T? FindByEmail(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>().Where(expression).SingleOrDefault()
                : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

      
    }
}
