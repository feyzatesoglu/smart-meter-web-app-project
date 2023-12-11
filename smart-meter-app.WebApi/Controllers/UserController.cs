[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly YourDatabaseContext _context; // Veritabanı bağlantısı

    public UserController(YourDatabaseContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser(UserDetailModel userData)
    {
        try
        {
            // userModel'deki bilgileri veritabanına kaydetme işlemi
            _context.Users.Add(userData);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Registration failed: {ex.Message}");
        }
    }
}
