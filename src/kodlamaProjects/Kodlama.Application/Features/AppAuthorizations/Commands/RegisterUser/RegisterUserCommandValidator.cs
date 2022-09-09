using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.AppAuthorizations.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty();
            RuleFor(a => a.FirstName).Length(3, 30);
            RuleFor(a => a.LastName).NotEmpty();
            RuleFor(a => a.LastName).Length(1, 30);
            RuleFor(a => a.Email).NotEmpty();
            RuleFor(a => a.Email).EmailAddress();
            RuleFor(a => a.Password).NotEmpty();
            RuleFor(a => a.LastName).MinimumLength(3);
        }
        
    }
}
