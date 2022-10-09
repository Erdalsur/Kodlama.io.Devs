using FluentValidation;

namespace Kodlama.Application.Features.UserOperationClaims.Commnads.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommandValidator:AbstractValidator<DeleteUserOperationClaimCommand>
    {
        public DeleteUserOperationClaimCommandValidator()
        {
            RuleFor(a => a.Id).NotNull().NotEmpty();
        }
    }
}
