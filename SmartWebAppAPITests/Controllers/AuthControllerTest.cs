using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using SmartWebAppAPI.Controllers;
using SmartWebAppAPI.Entity.Dto.AuthDto;
using SmartWebAppAPI.Entity.Models;
using SmartWebAppAPI.Repositories;
using SmartWebAppAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartWebAppAPITests.Controllers
{
  [TestFixture]
  public class AuthControllerTests
  {
    [Test]
    public void RegisterUser_ValidInput_ReturnsOkResult()
    {
      // Arrange
      var mockServiceManager = new Mock<IServiceManager>();
      var mockAuthService = new Mock<IAuthService>();
      var mockAuthRepo = new Mock<IAuthRepository>();
      var mockConfiguration = new Mock<IConfiguration>();
      mockServiceManager.Setup(manager => manager.AuthService).Returns(mockAuthService.Object);

      var authController = new AuthController(mockServiceManager.Object, mockConfiguration.Object);

      var registerDto = new RegisterDto
      {
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com",
        Password = "password123"
      };

      // Auth servisi CreateUser metodunu taklit et
      mockAuthService.Setup(service => service.GetOneUserbyEmail(registerDto.Email, It.IsAny<bool>()))
                     .Returns((User)null); // Kullanıcı zaten varsa null döndürsün

      // Act
      var result = authController.RegisterUser(registerDto);

      // Assert
      Assert.IsInstanceOf<OkResult>(result);
    }
    [Test]
    public void Login_ValidCredentials_ReturnsOkResult()
    {
      // Arrange
      var mockServiceManager = new Mock<IServiceManager>();
      var mockAuthService = new Mock<IAuthService>();
      var _mapper = new Mock<IMapper>();
      var mockConfiguration = new Mock<IConfiguration>();

      mockServiceManager.Setup(manager => manager.AuthService).Returns(mockAuthService.Object);

      var authController = new AuthController(mockServiceManager.Object, mockConfiguration.Object);

      var loginDto = new LoginDto
      {
        Email = "john.doe@example.com",
        Password = "password123"
      };

      var user = new User
      {
        Id = 1,
        FirstName="John",
        LastName="Doe",
        RoleId=2
      };

      mockAuthService.Setup(service => service.Login(loginDto.Email, loginDto.Password))
                     .Returns(user);

      mockAuthService.Setup(service => service.GetOneUserbyEmail(loginDto.Email, It.IsAny<bool>()))
                     .Returns(user);

      // Act
      var result = authController.Login(loginDto);

      // Assert
      Assert.IsInstanceOf<OkObjectResult>(result);
    }
    [Test]
    public void GetUserForUpdate_UserExists_ReturnsOkResultWithUserData()
    {
      // Arrange
      var mockServiceManager = new Mock<IServiceManager>();
      var mockAuthService = new Mock<IAuthService>();
      var mockConfiguration = new Mock<IConfiguration>();

      mockServiceManager.Setup(manager => manager.AuthService).Returns(mockAuthService.Object);

      var authController = new AuthController(mockServiceManager.Object, mockConfiguration.Object);

      var userId = 1;
      var userForUpdate = new GetUserForUpdateDto
      {
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com",
        RoleId = 1, // Örnek bir RoleId
        UserTypeId = 1 // Örnek bir UserTypeId
      };

      mockAuthService.Setup(service => service.GetUserByIdForUpdate(userId))
                     .Returns(userForUpdate);

      mockAuthService.Setup(service => service.GetRoleNameById(userForUpdate.RoleId))
                     .Returns("User"); // Örnek bir rol adı

      mockAuthService.Setup(service => service.GetTypeNameById(userForUpdate.UserTypeId))
                     .Returns("Normal"); // Örnek bir kullanıcı tipi adı

      // Act
      var result = authController.GetUserForUpdate(userId);

      // Assert
      Assert.IsInstanceOf<OkObjectResult>(result);

      var okResult = result as OkObjectResult;
      Assert.IsNotNull(okResult);

      var resultData = okResult.Value as UpdateDto;
      Assert.IsNotNull(resultData);

      Assert.AreEqual(userForUpdate.FirstName, resultData.FirstName);
      Assert.AreEqual(userForUpdate.LastName, resultData.LastName);
      Assert.AreEqual(userForUpdate.Email, resultData.Email);
      Assert.AreEqual("User", resultData.Role); // Mock ile belirlediğimiz role adı
      Assert.AreEqual("Normal", resultData.UserType); // Mock ile belirlediğimiz kullanıcı tipi adı
    }
    [Test]
    public void UpdatePassword_UnsuccessfulUpdate_ReturnsBadRequestResult()
    {
      // Arrange
      var mockServiceManager = new Mock<IServiceManager>();
      var mockAuthService = new Mock<IAuthService>();
      var mockConfiguration = new Mock<IConfiguration>();

      mockServiceManager.Setup(manager => manager.AuthService).Returns(mockAuthService.Object);

      var authController = new AuthController(mockServiceManager.Object, mockConfiguration.Object);

      var updatePasswordDto = new UpdatePasswordDto
      {
        email= "john.doe@example.com",
        OldPassword = "oldPassword",
        NewPassword = "newPassword"
      };

      mockAuthService.Setup(service => service.UpdatePassword(updatePasswordDto))
                     .Returns(false); // Şifre güncelleme başarısızsa

      // Act
      var result = authController.UpdatePassword(updatePasswordDto);

      // Assert
      Assert.IsInstanceOf<BadRequestResult>(result);
    }
    [Test]
    public void ForgetPassword_ValidForgetPasswordDto_ReturnsOkResult()
    {
      // Arrange
      var mockServiceManager = new Mock<IServiceManager>();
      var mockAuthService = new Mock<IAuthService>();
      var mockConfiguration = new Mock<IConfiguration>();

      mockServiceManager.Setup(manager => manager.AuthService).Returns(mockAuthService.Object);
      var authController = new AuthController(mockServiceManager.Object, mockConfiguration.Object);


      var forgetPasswordDto = new ForgetPasswordDto
      {
        email = "john.doe@example.com"
      };

      mockAuthService.Setup(service => service.GetOneUserbyEmail(forgetPasswordDto.email, It.IsAny<bool>()))
                     .Returns(new User()); // Kullanıcı varsa

      // Act
      var result = authController.ForgetPassword(forgetPasswordDto);

      // Assert
      Assert.IsInstanceOf<OkResult>(result);
    }
    [Test]
    public void ForgetPassword_InvalidForgetPasswordDto_ReturnsBadRequestResult()
    {
      // Arrange
      var mockServiceManager = new Mock<IServiceManager>();
      var mockAuthService = new Mock<IAuthService>();
      var mockConfiguration = new Mock<IConfiguration>();

      mockServiceManager.Setup(manager => manager.AuthService).Returns(mockAuthService.Object);

      var authController = new AuthController(mockServiceManager.Object, mockConfiguration.Object);

      var forgetPasswordDto = new ForgetPasswordDto
      {
        email=""
      };

      authController.ModelState.AddModelError("Email", "The Email field is required."); // ModelState hataları simüle et

      // Act
      var result = authController.ForgetPassword(forgetPasswordDto);

      // Assert
      Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }
    [Test]
    public void ForgetPassword_UserNotFound_ReturnsNotFoundResult()
    {
      // Arrange
      var mockServiceManager = new Mock<IServiceManager>();
      var mockAuthService = new Mock<IAuthService>();
      var mockConfiguration = new Mock<IConfiguration>();

      mockServiceManager.Setup(manager => manager.AuthService).Returns(mockAuthService.Object);

      var authController = new AuthController(mockServiceManager.Object, mockConfiguration.Object);

      var forgetPasswordDto = new ForgetPasswordDto
      {
        email = "nonexistent@example.com"
      };

      mockAuthService.Setup(service => service.GetOneUserbyEmail(forgetPasswordDto.email, It.IsAny<bool>()))
                     .Returns((User)null); // Kullanıcı yoksa

      // Act
      var result = authController.ForgetPassword(forgetPasswordDto);

      // Assert
      Assert.IsInstanceOf<NotFoundResult>(result);
    }
    [Test]
    public void GetUserProfile_ValidUserId_ReturnsOkResultWithUserProfile()
    {
      // Arrange
      var mockServiceManager = new Mock<IServiceManager>();
      var mockAuthService = new Mock<IAuthService>();
      var mockConfiguration = new Mock<IConfiguration>();


      mockServiceManager.Setup(manager => manager.AuthService).Returns(mockAuthService.Object);
      var authController = new AuthController(mockServiceManager.Object, mockConfiguration.Object);
  

      var userId = "1";
      var user = new User
      {
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com",
        RoleId = 1, // Örnek bir RoleId
        UserTypeId = 1 // Örnek bir UserTypeId
      };

      mockAuthService.Setup(service => service.GetOneUserbyId(int.Parse(userId), It.IsAny<bool>()))
                     .Returns(user);

      mockAuthService.Setup(service => service.GetRoleNameById(user.RoleId ?? 0))
                     .Returns("User"); // Örnek bir rol adı

      mockAuthService.Setup(service => service.GetTypeNameById(user.UserTypeId))
                     .Returns("SomeUserType"); // Örnek bir kullanıcı tipi adı

      var claims = new[]
      {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };

      authController.ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext { User = new ClaimsPrincipal(new ClaimsIdentity(claims, "test")) }
      };


      // Act
      var result = authController.GetUserProfile();

      // Assert
      Assert.IsInstanceOf<OkObjectResult>(result);

      var okResult = result as OkObjectResult;
      Assert.IsNotNull(okResult);

      var resultData = okResult.Value as object;

      // Profil bilgilerini doğrula
      Assert.IsNotNull(resultData);
      Assert.AreEqual(user.Id, resultData.GetType().GetProperty("Id")?.GetValue(resultData));
      Assert.AreEqual(user.FirstName, resultData.GetType().GetProperty("FirstName")?.GetValue(resultData));
      Assert.AreEqual(user.LastName, resultData.GetType().GetProperty("Surname")?.GetValue(resultData));
      Assert.AreEqual(user.Email, resultData.GetType().GetProperty("Email")?.GetValue(resultData));
      Assert.AreEqual("User", resultData.GetType().GetProperty("UserRole")?.GetValue(resultData));
      Assert.AreEqual("SomeUserType", resultData.GetType().GetProperty("UserType")?.GetValue(resultData));
    }

    [Test]
    public void GetUserProfile_InvalidUserId_ReturnsNotFoundResult()
    {
      // Arrange
      var mockServiceManager = new Mock<IServiceManager>();
      var mockAuthService = new Mock<IAuthService>();
      var mockConfiguration = new Mock<IConfiguration>();

      var authController = new AuthController(mockServiceManager.Object, mockConfiguration.Object);

      var userId = "invalidUserId";

      var claims = new[]
      {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };

      authController.ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext { User = new ClaimsPrincipal(new ClaimsIdentity(claims, "test")) }
      };


      // Act
      var result = authController.GetUserProfile();

      // Assert
      Assert.IsInstanceOf<NotFoundObjectResult>(result);
    }

  }

}
