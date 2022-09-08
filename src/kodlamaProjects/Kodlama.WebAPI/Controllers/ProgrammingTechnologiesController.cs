using Core.Application.Requests;
using Core.Persistence.Dynamic;
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
    }
}
