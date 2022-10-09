using Core.Application.Requests;
using Kodlama.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile;
using Kodlama.Application.Features.UserOperationClaims.Commnads.CreateUserOperationClaim;
using Kodlama.Application.Features.UserOperationClaims.Commnads.DeleteUserOperationClaim;
using Kodlama.Application.Features.UserOperationClaims.Commnads.UpdateUserOperationClaim;
using Kodlama.Application.Features.UserOperationClaims.Dtos;
using Kodlama.Application.Features.UserOperationClaims.Models;
using Kodlama.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaims;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto createdUserOperationClaimDto = await Mediator.Send(createUserOperationClaimCommand);
            return Ok(createdUserOperationClaimDto);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            UpdatedUserOperationClaimDto updatedUserOperationClaimDto = await Mediator.Send(updateUserOperationClaimCommand);
            return Ok(updatedUserOperationClaimDto);
        }

        [HttpPost("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeletedUserOperationClaimDto deletedUserOperationClaimDto = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(deletedUserOperationClaimDto);
        }

        [HttpGet("GetUserId")]
        public async Task<IActionResult> GetUserId([FromQuery] PageRequest pageRequest, [FromQuery] int UserId)
        {
            GetByIdUserOperationClaimsQuery getByIdUserOperationClaimsQuery = new() { UserId = UserId, PageRequest = pageRequest };
            UserOperationClaimsListByUserModel userOperationClaimsListByUserModel = await Mediator.Send(getByIdUserOperationClaimsQuery);
            return Ok(userOperationClaimsListByUserModel);

        }
    }
}
