



using System.Data.Entity;
using System.Linq;
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

    public IQueryable<T> FindAll(bool trackChanges)=>_context.Set<T>().AsNoTracking();
    

    public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
      return trackChanges
               ? _context.Set<T>().Where(expression).SingleOrDefault()
               : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
    }

   

    public void Remove(T entity)
    {
      _context.Set<T>().Remove(entity);

      
    }

    public void Update(T entity)
    {
      _context.Set<T>().Update(entity);
    }
  }
}
