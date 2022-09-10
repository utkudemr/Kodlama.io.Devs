using Application.Features.GithubProfiles.Commands.CreateGithubSocial;
using FluentValidation;

namespace Application.Features.GithubProfiles.Commands.UpdateGithubSocial
{
    public class UpdateGithubSocialValidator : AbstractValidator<UpdateGithubSocialCommand>
    {
        public UpdateGithubSocialValidator()
        {
            RuleFor(c => c.GithubUrl).NotEmpty();
            RuleFor(c => c.UserId).NotNull();
        }
    }
}
