using FluentValidation;

namespace Kodlama.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommandValidator : AbstractValidator<DeleteOperationClaimCommand>
    {
        public DeleteOperationClaimCommandValidator()
        {
            RuleFor(a => a.Id).NotNull();
            RuleFor(a => a.Id).NotEmpty();
        }
    }
}
