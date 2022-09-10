using FluentValidation;

namespace Kodlama.Application.Features.GitHubProfiles.Commands.CreatedGithubProfile
{
    public class CreatedGitHubProfileCommandValidator : AbstractValidator<CreatedGitHubProfileCommand>
    {
        public CreatedGitHubProfileCommandValidator()
        {
            RuleFor(a => a.UserId).NotEmpty();
            RuleFor(a => a.GitHubUrl).NotEmpty();
            RuleFor(a => a.GitHubUrl).Must(LinkMustBeAUri);
        }
        private static bool LinkMustBeAUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            //Courtesy of @Pure.Krome's comment and https://stackoverflow.com/a/25654227/563532
            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }

    }
}
