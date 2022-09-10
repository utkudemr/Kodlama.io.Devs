using Application.Features.Languages.Commands.UpdateProgrammingLanguage;
using FluentValidation;

namespace Application.Features.Languages.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
