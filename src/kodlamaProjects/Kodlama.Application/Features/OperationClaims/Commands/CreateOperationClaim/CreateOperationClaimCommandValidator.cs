using FluentValidation;

namespace Kodlama.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommandValidator:AbstractValidator<CreateOperationClaimCommand>
    {
        public CreateOperationClaimCommandValidator()
        {
            RuleFor(a => a.Name).NotNull();
            RuleFor(a => a.Name).MinimumLength(2);
        }
    }
}
