using Microsoft.EntityFrameworkCore;
using SmartWebAppAPI.Entity.Models;


namespace SmartWebAppAPI.Repositories
{
  public class RepositoryContext : DbContext
  {

    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> Roles { get; set; }
    public DbSet<UserType> UserType { get; set; }
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      

      

      modelBuilder.Entity<UserType>()
          .HasKey(u => u.UserTypeId);

      modelBuilder.Entity<UserRole>()
          .HasKey(u => u.RoleId);


    }
  }
}
