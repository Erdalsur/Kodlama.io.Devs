using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.Application.Features.ProgrammingTechnologies.Command.DeletedProgrammingTechnology;
using Kodlama.Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnology;
using Kodlama.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology;
using Kodlama.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyDynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProgrammingTechnologiesController:BaseController
    {
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new GetListProgrammingLanguageQuery { PageRequest = pageRequest };
            ProgrammingTechnologyListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListProgrammingLanguageByDynamicQuery getListProgrammingLanguageByDynamicQuery = new GetListProgrammingLanguageByDynamicQuery { PageRequest = pageRequest,Dynamic=dynamic };
            ProgrammingTechnologyListModel result = await Mediator.Send(getListProgrammingLanguageByDynamicQuery);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingTechnologyCommand updateProgrammingTechnologyCommand)
        {
            UpdatedPrgrammingTechnologyDto result = await Mediator.Send(updateProgrammingTechnologyCommand);
            return Ok(result);
        }

        [HttpPost("Delete/{Id}")]
        public async Task<IActionResult> DeletedById([FromRoute] DeletedByIdProgrammingTechnologyCommand deletedByIdProgrammingTechnologyCommand)
        {
            DeletedPrgrammingTechnologyDto result = await Mediator.Send(deletedByIdProgrammingTechnologyCommand);
            return Ok(result);
        }
    }
}
