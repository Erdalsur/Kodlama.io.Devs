using FluentValidation;

namespace Kodlama.Application.Features.Auths.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(a => a.UserForLoginDto.Email).NotNull();
            RuleFor(a => a.UserForLoginDto.Email).EmailAddress();
            RuleFor(a => a.UserForLoginDto.Password).NotNull();
            RuleFor(a => a.UserForLoginDto.Password).MinimumLength(3);
        }
    }
}
