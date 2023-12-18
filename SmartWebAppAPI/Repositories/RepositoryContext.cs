using Microsoft.EntityFrameworkCore;
using SmartWebAppAPI.Entity.Models;


namespace SmartWebAppAPI.Repositories
{
    public class RepositoryContext: DbContext
    {

        public DbSet<User> Users { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
    }
}
