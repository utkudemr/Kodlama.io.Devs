using Application.Features.Languages.Commands.UpdateProgrammingLanguage;
using FluentValidation;

namespace Application.Features.Languages.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
        }
    }
}
