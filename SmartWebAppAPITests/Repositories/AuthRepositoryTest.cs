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
    public void GetOneUserbyEmail_ValidEmail_ReturnsUser()
    {
      // Arrange
      var mockRepositoryContext = new Mock<RepositoryContext>();
      var authRepository = new AuthRepository(mockRepositoryContext.Object);

      var userEmail = "test@example.com";
      var user = new User
      {
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        Email = userEmail
      };

      // Mock the FindByCondition method
      mockRepositoryContext.Setup(context => context.Set<User>())
                           .Returns((Microsoft.EntityFrameworkCore.DbSet<User>)new[] { user }.AsQueryable());

      // Act
      var result = authRepository.GetOneUserbyEmail(userEmail, trackChanges: false);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(userEmail, result.Email);
      // Diğer özellikleri de doğrulayabilirsiniz.
    }

    [Test]
    public void GetOneUserbyEmail_InvalidEmail_ReturnsNull()
    {
      // Arrange
      var mockRepositoryContext = new Mock<RepositoryContext>();
      var authRepository = new AuthRepository(mockRepositoryContext.Object);

      var userEmail = "nonexistent@example.com";

      // Mock the FindByCondition method
      mockRepositoryContext.Setup(context => context.Set<User>())
                           .Returns((Microsoft.EntityFrameworkCore.DbSet<User>)Enumerable.Empty<User>().AsQueryable());

      // Act
      var result = authRepository.GetOneUserbyEmail(userEmail, trackChanges: false);

      // Assert
      Assert.IsNull(result);
    }
    [Test]
    public void DeleteUser_ValidUser_RemovesUserFromContext()
    {
      // Arrange
      var mockDbContextOptions = new DbContextOptionsBuilder<RepositoryContext>().Options;
      var mockRepositoryContext = new Mock<RepositoryContext>(mockDbContextOptions);
      var authRepository = new AuthRepository(mockRepositoryContext.Object);

      var user = new User
      {
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com"
      };

      // Mock the DbSet<User> with SetupData extension
      var mockUserSet = new Mock<DbSet<User>>().SetupData(new[] { user });
      mockRepositoryContext.Setup(context => context.Set<User>()).Returns(mockUserSet.Object);

      // Act
      authRepository.DeleteUser(user);

      // Assert
      mockRepositoryContext.Verify(context => context.Remove(user), Times.Once);
      mockRepositoryContext.Verify(context => context.SaveChanges(), Times.Once);
    }
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
    [Test]
    public void Register_ValidUser_CallsAddMethodWithUser()
    {
      // Arrange
      var mockRepositoryContext = new Mock<IRepositoryBase<User>>();
      var authRepository = new AuthRepository((RepositoryContext)mockRepositoryContext.Object);

      var user = new User
      {
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com"
      };

      // Act
      authRepository.Register(user);

      // Assert
      // Verify that Add method is called with the correct user
      mockRepositoryContext.Verify(context => context.Add(user), Times.Once);
    }
    [Test]
    public void GetAllUsers_TrackChangesFalse_CallsFindAllWithFalse()
    {
      // Arrange
      var mockRepositoryContext = new Mock<IRepositoryBase<User>>();
      var authRepository = new AuthRepository((RepositoryContext)mockRepositoryContext.Object);

      // Act
      var result = authRepository.GetAllUsers(trackChanges: false);

      // Assert
      // Verify that FindAll method is called with the correct parameter
      mockRepositoryContext.Verify(context => context.FindAll(false), Times.Once);
    }
    [Test]
    public void UpdateOneUser_ValidUser_CallsUpdateMethodWithUser()
    {
      // Arrange
      var mockRepositoryContext = new Mock<IRepositoryBase<User>>();
      var authRepository = new AuthRepository((RepositoryContext)mockRepositoryContext.Object);

      var user = new User
      {
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com"
      };

      // Act
      authRepository.UpdateOneUser(user);

      // Assert
      // Verify that Update method is called with the correct user
      mockRepositoryContext.Verify(context => context.Update(user), Times.Once);
    }
    [Test]
    public void GetUsersByCondition_ValidCondition_ReturnsFilteredUsers()
    {
      // Arrange
      var mockRepositoryContext = new Mock<IAuthRepository>();
      var authRepository = new AuthRepository((RepositoryContext)mockRepositoryContext.Object);

      var users = new List<User>
    {
        new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
        new User { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" },
        // Diğer kullanıcıları ekleyin
    };

      // Mock the GetAllUsers method
      mockRepositoryContext.Setup(context => context.GetAllUsers(false)).Returns(users.AsQueryable());

      // Act
      var result = authRepository.GetUsersByCondition(u => u.FirstName == "John");

      // Assert
      // Verify that GetAllUsers method is called with the correct parameter
      mockRepositoryContext.Verify(context => context.GetAllUsers(false), Times.Once);

      // Verify that Where method is called with the correct condition
      Assert.AreEqual(1, result.Count()); // veya diğer beklenen sonuçları kontrol edebilirsiniz
      Assert.IsTrue(result.All(u => u.FirstName == "John"));
    }



  }
}
