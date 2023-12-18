using FluentValidation;
using SmartWebAppAPI.Entity.Dto;

namespace SmartWebAppAPI.Validators.AuthValidators
{
    public class AuthValidationRegister : AbstractValidator<RegisterDto>
    {
        public AuthValidationRegister() {


            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty").Length(3, 20).WithMessage("Username must be between 3 and 20 characters");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches("[+!@#$%^&*]").WithMessage("Password must contain at least one special character");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Password must be at least 8 characters");
        }
    }
}
