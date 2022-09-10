using FluentValidation;

namespace Kodlama.Application.Features.AppAuthorizations.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty();

            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
