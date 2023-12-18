using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartWebAppAPI.Entity.Dto;
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
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }




    }

}

