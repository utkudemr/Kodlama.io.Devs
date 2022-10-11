using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaimCommand
{
    public class UpdateUserOperationClaimValidator : AbstractValidator<UpdateUserOperationClaimCommand>
    {
        public UpdateUserOperationClaimValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.OperationClaimId).NotEmpty().NotNull();
        }
    }
}
