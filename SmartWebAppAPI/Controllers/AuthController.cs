using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartWebAppAPI.Entity.Dto.AuthDto;
using SmartWebAppAPI.Entity.Models;
using SmartWebAppAPI.Infrastructure;
using SmartWebAppAPI.Repositories;
using SmartWebAppAPI.Services;
using System.Security.Claims;

namespace SmartWebAppAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {

    private readonly IServiceManager _manager;
    private readonly IConfiguration _configuration;

    public AuthController(IServiceManager manager, IConfiguration configuration)
    {
      _manager = manager;
      _configuration = configuration;
    }

    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] RegisterDto registerDto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); // ModelState'deki hata detaylarını döndür
      }

      try
      {
        var user = _manager.AuthService.GetOneUserbyEmail(registerDto.Email, trackChanges: false);

        if (user is not null)
        {
          // Kullanıcı zaten varsa hata döndür
          return Conflict("User with this email already exists");
        }



        _manager.AuthService.CreateUser(registerDto);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.InnerException.Message);
      }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
      var user = _manager.AuthService.Login(loginDto.Email, loginDto.Password);

      if (user == null)
      {
        return Unauthorized();
      }

      var userType = "User";
      var userRole = _manager.AuthService.GetOneUserbyEmail(loginDto.Email, trackChanges: false)?.RoleId;

      if (userRole == _manager.AuthService.GetRoleIdByName("Admin"))
      {
        userType = "Admin";
      }

      var secretKey = _configuration["JwtConfig:SecretKey"];
      var issuer = _configuration["JwtConfig:Issuer"];
      var audience = _configuration["JwtConfig:Audience"];

      var jwtService = new Jwt(secretKey, issuer, audience);
      var token = jwtService.GenerateToken(user.Id.ToString(), userType);

      return Ok(new { token, userType });
    }


    [HttpGet("get-update-user/{id}")]
    public IActionResult GetUserForUpdate(int id)
    {
      var userForUpdate = _manager.AuthService.GetUserByIdForUpdate(id);

      if (userForUpdate == null)
      {
        return NotFound();
      }

      var user = new UpdateDto
      {
        FirstName = userForUpdate.FirstName,
        LastName = userForUpdate.LastName,
        Email = userForUpdate.Email,
        Role = _manager.AuthService.GetRoleNameById(userForUpdate.RoleId),
        UserType = _manager.AuthService.GetTypeNameById(userForUpdate.UserTypeId)
      };





      return Ok(user);
    }

    [HttpPut("update-user/{id}")]
    public IActionResult UpdateUser(int id, UpdateDto updateDto)
    {
      try
      {

         _manager.AuthService.UpdateUser(updateDto, id);
               
        
        
           return Ok();
        
        

       

      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.InnerException.Message);
      }



    }


    [HttpPost("update-password")]
    public IActionResult UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto)
    {

      var success = _manager.AuthService.UpdatePassword(updatePasswordDto);

      if (success)
      {
        return Ok();
      }

      return BadRequest();
    }


    //forget password
    [HttpPost("forget-password")]
    public IActionResult ForgetPassword([FromBody] ForgetPasswordDto forgetPasswordDto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState); // ModelState'deki hata detaylarını döndür
      }
      if (_manager.AuthService.GetOneUserbyEmail(forgetPasswordDto.email, trackChanges: false) == null)
      {
        return NotFound();
      }

      _manager.AuthService.ForgetPassword(forgetPasswordDto);
      return Ok();
    }

    [HttpGet("profile")]
    [Authorize]
    public IActionResult GetUserProfile()
    {
      var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      // Veritabanından kullanıcıyı bul
      var user = _manager.AuthService.GetOneUserbyId(int.Parse(userId), trackChanges: false);

      if (user == null)
      {
        return NotFound("Kullanıcı bulunamadı.");
      }

      var role = _manager.AuthService.GetRoleNameById(user.RoleId ?? 0);
      var type = _manager.AuthService.GetTypeNameById(user.UserTypeId);
      // Kullanıcı bilgilerini döndür
      var userProfile = new { Id = user.Id, FirstName = user.FirstName, Surname = user.LastName, Email = user.Email, UserRole = role, UserType = type };
      return Ok(userProfile);
    }
  }
}







