using FluentValidation;

namespace Kodlama.Application.Features.UserOperationClaims.Commnads.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommandValidator:AbstractValidator<CreateUserOperationClaimCommand>
    {
        public CreateUserOperationClaimCommandValidator()
        {
            RuleFor(a => a.UserId).NotNull().NotEmpty();
            RuleFor(a => a.OperationClaimId).NotNull().NotEmpty();
        }
    }
}
