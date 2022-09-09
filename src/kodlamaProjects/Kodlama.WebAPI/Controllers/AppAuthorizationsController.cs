using Kodlama.Application.Features.AppAuthorizations.Commands.RegisterUser;
using Kodlama.Application.Features.AppAuthorizations.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppAuthorizationsController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            UserDto result = await Mediator.Send(registerUserCommand);
            return Ok(result);
        }
    }
}
