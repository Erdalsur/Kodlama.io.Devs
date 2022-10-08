using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Kodlama.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.Application.Features.OperationClaims.Dtos;
using Kodlama.Application.Features.OperationClaims.Models;
using Kodlama.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using Kodlama.Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Kodlama.Application.Features.OperationClaims.Queries.GetListOperationClaimByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto createdOperationClaimDto = await Mediator.Send(createOperationClaimCommand);
            return Ok(createdOperationClaimDto);
        }

        [HttpPost("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeletedOperationClaimDto deletedOperationClaimDto = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(deletedOperationClaimDto);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdatedOperationClaimDto updatedOperationClaimDto = await Mediator.Send(updateOperationClaimCommand);
            return Ok(updatedOperationClaimDto);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new GetListOperationClaimQuery { PageRequest = pageRequest };
            OperationClaimListModel operationClaimListModel = await Mediator.Send(getListOperationClaimQuery);
            return Ok(operationClaimListModel);
        }
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOperationClaimQuery getByIdOperationClaimQuery)
        {
            OperationClaimGetByIdDto operationClaimGetByIdDto = await Mediator.Send(getByIdOperationClaimQuery);
            return Ok(operationClaimGetByIdDto);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListOperationClaimByDynamicQuery getListOperationClaimByDynamicQuery = new GetListOperationClaimByDynamicQuery { Dynamic = dynamic, PageRequest = pageRequest };
            OperationClaimListModel operationClaimListModel = await Mediator.Send(getListOperationClaimByDynamicQuery);
            return Ok(operationClaimListModel);
        }


    }
}
