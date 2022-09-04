using Application.Features.Language.Commands.UpdateProgrammingLanguage;
using FluentValidation;

namespace Application.Features.Language.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
        }
    }
}
