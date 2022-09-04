using AutoMapper;
using Kodlama.Application.Features.Lessons.Dtos;
using Kodlama.Application.Features.Lessons.Rules;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.Lessons.Commands.DeletedLesson
{
    public class DeletedByIdLessonCommand:IRequest<DeletedLessonDto>
    {
        public int Id { get; set; }

        public class DeletedByIdLessonCommandHandler : IRequestHandler<DeletedByIdLessonCommand, DeletedLessonDto>
        {
            private readonly ILessonRepository _lessonRepository;
            private readonly IMapper _mapper;
            private readonly LessonBusinessRules _lessonBusinessRules;

            public DeletedByIdLessonCommandHandler(ILessonRepository lessonRepository, IMapper mapper, LessonBusinessRules lessonBusinessRules)
            {
                _lessonRepository = lessonRepository;
                _mapper = mapper;
                _lessonBusinessRules = lessonBusinessRules;
            }

            public async Task<DeletedLessonDto> Handle(DeletedByIdLessonCommand request, CancellationToken cancellationToken)
            {
                _lessonBusinessRules.LessonIdShouldExistWhenRequested(request.Id);

                Lesson? lesson = await _lessonRepository.GetAsync(a => a.Id == request.Id);
                _lessonBusinessRules.LessonShouldExistWhenRequested(lesson);
                Lesson deletedLesson = await _lessonRepository.DeleteAsync(lesson);
                DeletedLessonDto deletedLessonDto = _mapper.Map<DeletedLessonDto>(deletedLesson);
                return deletedLessonDto;

            }
        }
    }
}
