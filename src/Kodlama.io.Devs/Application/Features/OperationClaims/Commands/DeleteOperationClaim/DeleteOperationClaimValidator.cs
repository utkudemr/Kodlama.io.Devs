using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimValidator : AbstractValidator<DeleteOperationClaimCommand>
    {
        public DeleteOperationClaimValidator()
        {

            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
