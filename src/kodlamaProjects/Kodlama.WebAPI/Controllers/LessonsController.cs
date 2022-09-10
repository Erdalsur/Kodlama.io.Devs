using Core.Application.Requests;
using Kodlama.Application.Features.Lessons.Commands.CreatedLesson;
using Kodlama.Application.Features.Lessons.Commands.DeletedLesson;
using Kodlama.Application.Features.Lessons.Commands.UpdateLesson;
using Kodlama.Application.Features.Lessons.Dtos;
using Kodlama.Application.Features.Lessons.Models;
using Kodlama.Application.Features.Lessons.Queries.GetByIdLesson;
using Kodlama.Application.Features.Lessons.Queries.GetListLesson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : BaseController
    {
        
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateLessonCommand createLessonCommand)
        {
            CreatedLessonDto result = await Mediator.Send(createLessonCommand);
            return Created("",result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLessonQuery getListLessonQuery=new() { PageRequest = pageRequest };
            LessonListModel result = await Mediator.Send(getListLessonQuery);
            return Ok(result);

        }
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLessonQuery getByIdLessonQuery)
        {

            LessonGetByIdDto lessonGetByIdDto = await Mediator.Send(getByIdLessonQuery);
            return Ok(lessonGetByIdDto);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdatedLessonCommand updatedLessonCommand)
        {
            UpdatedLessonDto result = await Mediator.Send(updatedLessonCommand);
            return Ok(result);
        }

        [HttpPost("Delete/{Id}")]
        public async Task<IActionResult> DeletedById([FromRoute] DeletedByIdLessonCommand deletedByIdLessonCommand)
        {
            DeletedLessonDto result = await Mediator.Send(deletedByIdLessonCommand);
            return Ok(result);
        }
    }
}
