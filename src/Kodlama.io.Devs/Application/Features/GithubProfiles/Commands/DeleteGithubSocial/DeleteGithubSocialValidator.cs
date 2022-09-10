
using Application.Features.GithubProfiles.Commands.DeleteGithubSocial;
using FluentValidation;

namespace Application.Features.GithubProfiles.Commands.UpdateGithubSocial
{
    public class DeleteGithubSocialValidator : AbstractValidator<DeleteGithubSocialCommand>
    {
        public DeleteGithubSocialValidator()
        {
            RuleFor(c => c.Id).NotNull();
        }
    }
}
