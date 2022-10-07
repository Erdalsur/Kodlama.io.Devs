using FluentValidation;
using System.Net;
using System.Net.Sockets;

namespace Kodlama.Application.Features.Auths.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(a => a.UserForRegisterDto.Email).EmailAddress();
            RuleFor(a => a.UserForRegisterDto.Email).NotEmpty();
            RuleFor(a => a.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(a => a.UserForRegisterDto.FirstName).Length(3, 30);
            RuleFor(a => a.UserForRegisterDto.LastName).NotEmpty();
            RuleFor(a => a.UserForRegisterDto.LastName).Length(3, 30);
            RuleFor(a => a.UserForRegisterDto.Password).NotEmpty();
            RuleFor(a => a.UserForRegisterDto.Password).MinimumLength(3);


        }
    }
}
