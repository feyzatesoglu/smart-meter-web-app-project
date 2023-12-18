using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartWebAppAPI.Repositories;

namespace SmartWebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RepositoryContext _context; // Veritabanı bağlantısı için DbContext

        public UserController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();

            if (users == null || !users.Any())
            {
                return NotFound(); // Kullanıcı bulunamazsa 404 hatası gönder
            }

            return Ok(users); // Tüm kullanıcı verilerini JSON formatında dön
        }

    }
}
