using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SmartWebAppAPI.Entity.Models;
using SmartWebAppAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartWebAppAPITests.Repositories
{
  public static class DbSetExtensions
  {
    public static Mock<DbSet<T>> SetupData<T>(this Mock<DbSet<T>> mockSet, IEnumerable<T> data) where T : class
    {
      var queryableData = data.AsQueryable();
      mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
      mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
      mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
      mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryableData.GetEnumerator());
      return mockSet;
    }
  }
  [TestFixture]
  public class AuthRepositoryTest
  {

    [Test]
    public void DeleteUser_InvalidUser_DoesNotRemoveFromContext()
    {
      // Arrange
      var mockDbContextOptions = new DbContextOptionsBuilder<RepositoryContext>().Options;
      var mockRepositoryContext = new Mock<RepositoryContext>(mockDbContextOptions);
      var authRepository = new AuthRepository(mockRepositoryContext.Object);

      var invalidUser = new User
      {
        Id = 99, // Some non-existent ID
        FirstName = "Invalid",
        LastName = "User",
        Email = "invalid.user@example.com"
      };

      // Mock the DbSet<User> with SetupData extension
      var mockUserSet = new Mock<DbSet<User>>().SetupData(new User[] { /* Empty List */ });
      mockRepositoryContext.Setup(context => context.Set<User>()).Returns(mockUserSet.Object);

      // Act
      authRepository.DeleteUser(invalidUser);

      // Assert
      mockRepositoryContext.Verify(context => context.Remove(invalidUser), Times.Never);
      mockRepositoryContext.Verify(context => context.SaveChanges(), Times.Never);
    }
  }
}
