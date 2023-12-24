using Microsoft.AspNetCore.Mvc;
using SmartWebAppAPI.Services;

namespace SmartWebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthAdminController : ControllerBase{

         private readonly IServiceManager _manager;

    public AuthAdminController(IServiceManager manager)
    {
      _manager = manager;
    }

    [HttpGet("GetAllUser")]
        public IActionResult GetAllUsers()
        {
            var users = _manager.AuthService.GetAllUsers();

            if (users == null || !users.Any())
            {
                return NotFound(); // Kullanıcı bulunamazsa 404 hatası gönder
            }

            return Ok(users); // Tüm kullanıcı verilerini JSON formatında dön
        }


        [HttpDelete("delete-user/{id}")]
public IActionResult DeleteUser(int id)
{
    var user = _manager.AuthService.GetOneUserbyId(id,false);
    if (user == null)
    {
        return NotFound();
    }

    _manager.AuthService.DeleteUser(user.Id);
    

    return Ok("delete successful");
}
  }
}