using System.ComponentModel.DataAnnotations;

namespace SmartWebAppAPI.Entity.Dto
{
    public record  RegisterDto
    {
        [Required(ErrorMessage ="Username is required")]
        public string? Username { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
    }
}
