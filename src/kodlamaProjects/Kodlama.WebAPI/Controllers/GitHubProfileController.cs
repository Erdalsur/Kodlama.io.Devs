using Kodlama.Application.Features.GitHubProfiles.Commands.CreatedGithubProfile;
using Kodlama.Application.Features.GitHubProfiles.Commands.DeletedGitHubProfile;
using Kodlama.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile;
using Kodlama.Application.Features.GitHubProfiles.Dtos;
using Kodlama.Application.Features.GitHubProfiles.Queries.GetByUserIdGitHubProfile;
using Kodlama.Application.Features.Lessons.Dtos;
using Kodlama.Application.Features.Lessons.Queries.GetByIdLesson;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubProfilesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreatedGitHubProfileCommand createdGitHubProfileCommand)
        {
            CreatedGitHubProfileDto result = await Mediator.Send(createdGitHubProfileCommand);
            return Created("", result);
        }

        [HttpPost("Delete/{Id}")]
        public async Task<IActionResult> DeletedById([FromRoute] DeletedGitHubProfileCommand deletedGitHubProfileCommand)
        {
            DeletedGitHubProfileDto result = await Mediator.Send(deletedGitHubProfileCommand);
            return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdatedGitHubProfileCommand updatedGitHubProfileCommand)
        {
            UpdatedGitHubProfileDto result = await Mediator.Send(updatedGitHubProfileCommand);
            return Ok(result);
        }

        [HttpGet("Get/{UserId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] GetByUserIdGitHubProfileQuery getByUserIdGitHubProfileQuery)
        {

            GitHubProfileGetByUserIdDto gitHubProfileGetByUserIdDto = await Mediator.Send(getByUserIdGitHubProfileQuery);
            return Ok(gitHubProfileGetByUserIdDto);
        }

    }
}
