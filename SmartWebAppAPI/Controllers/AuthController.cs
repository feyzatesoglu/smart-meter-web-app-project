using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartWebAppAPI.Entity.Dto.AuthDto;
using SmartWebAppAPI.Entity.Models;
using SmartWebAppAPI.Repositories;
using SmartWebAppAPI.Services;

namespace SmartWebAppAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {

    private readonly IServiceManager _manager;

    public AuthController(IServiceManager manager)
    {
      _manager = manager;
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

    private string GenerateUserToken(User user)
{
    return "User"; // Kullanıcı token'ı
}

private string GenerateAdminToken(User user)
{
    return "Admin"; // Admin token'ı
}

[HttpPost("login")]
public IActionResult Login([FromBody] LoginDto loginDto)
{
    var user = _manager.AuthService.Login(loginDto.Email, loginDto.Password);

    if (user == null)
    {
        return Unauthorized();
    }

    var _user = _manager.AuthService.GetOneUserbyEmail(loginDto.Email, trackChanges: false);

    if (_user.RoleId == _manager.AuthService.GetRoleIdByName("Admin"))
    {
        var adminToken = GenerateAdminToken(user); // Admin token'ı oluştur
        return Ok(new { token = adminToken, userType = "Admin" }); // Admin kullanıcı için token ve userType döndür
    }
    else if (_user.RoleId == _manager.AuthService.GetRoleIdByName("User"))
    {
        var userToken = GenerateUserToken(user); // Kullanıcı token'ı oluştur
        return Ok(new { token = userToken, userType = "User" }); // Normal kullanıcı için token ve userType döndür
    }
    else
    {
        return Unauthorized();
    }
}



    [HttpGet("get-update-user/{id}")]
    public IActionResult GetUserForUpdate(int id)
    {
      var userForUpdate = _manager.AuthService.GetUserByIdForUpdate(id);

      if (userForUpdate == null)
      {
        return NotFound();
      }

      return Ok(userForUpdate);
    }

    [HttpPut("update-user/{id}")]
    public IActionResult UpdateUser(int id, UpdateDto updateDto)
    {
      if (id != updateDto.Id)
      {
        return BadRequest("ID mismatch between route and body.");
      }

      _manager.AuthService.UpdateUser(updateDto);

      return NoContent();
    }


    [HttpPost("update-password")]
    public IActionResult UpdatePassword([FromBody]UpdatePasswordDto updatePasswordDto)
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


  }
}








