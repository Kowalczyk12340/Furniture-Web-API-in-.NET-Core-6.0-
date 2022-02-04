using FluentValidation;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;

namespace FurnitureAPI.Validators
{
  public class RegisterUserDtoValidator : AbstractValidator<RegisterDto>
  {
    public RegisterUserDtoValidator(FurnitureDbContext dbContext)
    {
      RuleFor(x => x.Login).NotEmpty().EmailAddress();
      
      RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
      
      RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

      RuleFor(x => x.DateOfBirth.Value.Year).GreaterThan(17);

      RuleFor(x => x.Login)
        .Custom((value, context) =>
        {
          var loginInUse = dbContext.Users.Any(u => u.Login == value);
          if(loginInUse)
          {
            context.AddFailure("Login", "That Login is taken");
          }
        });
    }
  }
}