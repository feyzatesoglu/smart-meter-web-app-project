using FluentValidation;
using SmartWebAppAPI.Entity.Dto.AuthDto;

namespace SmartWebAppAPI.Validators.AuthValidators
{
  public class RegisterValidation : AbstractValidator<RegisterDto>
  {
    
    public RegisterValidation()
    {

      RuleFor(x => x.FirstName)
          .NotEmpty().WithMessage("First name cannot be empty")
          .Length(3, 20).WithMessage("First name must be between 3 and 20 characters");

      RuleFor(x => x.LastName)
          .NotEmpty().WithMessage("Last name cannot be empty")
          .Length(3, 20).WithMessage("Last name must be between 3 and 20 characters");

      RuleFor(x => x.Email)
          .NotEmpty().WithMessage("Email cannot be empty")
          .EmailAddress().WithMessage("Invalid email address");

      RuleFor(x => x.Password)
          .NotEmpty().WithMessage("Password cannot be empty")
          .MinimumLength(6).WithMessage("Password must be at least 6 characters")
          .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
          .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
          .Matches("[+!@#$%^&*]").WithMessage("Password must contain at least one special character");

    }
  }
}
