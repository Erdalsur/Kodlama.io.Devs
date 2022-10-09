using FluentValidation;

namespace Kodlama.Application.Features.UserOperationClaims.Commnads.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommandValidator:AbstractValidator<UpdateUserOperationClaimCommand>
    {
        public UpdateUserOperationClaimCommandValidator()
        {
            RuleFor(a => a.Id).NotNull().NotEmpty();
            RuleFor(a => a.UserId).NotNull().NotEmpty();
            RuleFor(a => a.OperationClaimId).NotNull().NotEmpty();
        }
    }
}
