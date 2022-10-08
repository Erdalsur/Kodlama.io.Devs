using FluentValidation;

namespace Kodlama.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimCommandValidator()
        {
            RuleFor(a => a.Name).NotNull();
            RuleFor(a => a.Name).MinimumLength(2);
            RuleFor(a => a.Id).NotNull();
            RuleFor(a => a.Id).NotEmpty();
        }
    }
}
