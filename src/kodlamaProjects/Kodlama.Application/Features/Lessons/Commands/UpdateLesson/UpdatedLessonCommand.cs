using AutoMapper;
using Kodlama.Application.Features.Lessons.Commands.CreatedLesson;
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

namespace Kodlama.Application.Features.Lessons.Commands.UpdateLesson
{
    public class UpdatedLessonCommand:IRequest<UpdatedLessonDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdatedLessonCommandHandler:IRequestHandler<UpdatedLessonCommand,UpdatedLessonDto>
        {
            private readonly ILessonRepository _lessonRepository;
            private readonly IMapper _mapper;
            private readonly LessonBusinessRules _lessonBusinessRules;

            public UpdatedLessonCommandHandler(ILessonRepository lessonRepository, IMapper mapper, LessonBusinessRules lessonBusinessRules)
            {
                _lessonRepository = lessonRepository;
                _mapper = mapper;
                _lessonBusinessRules = lessonBusinessRules;
            }

            public async Task<UpdatedLessonDto> Handle(UpdatedLessonCommand request, CancellationToken cancellationToken)
            {
                _lessonBusinessRules.LessonIdShouldExistWhenRequested(request.Id);
                await _lessonBusinessRules.LessonNameCanNotBeDuplicatedWhenInsert(request.Name);

                Lesson mappedLesson = _mapper.Map<Lesson>(request);
                Lesson updateLesson = await _lessonRepository.UpdateAsync(mappedLesson);
                UpdatedLessonDto updateLessonDto = _mapper.Map<UpdatedLessonDto>(updateLesson);

                return updateLessonDto;
            }
        }
    }
}
