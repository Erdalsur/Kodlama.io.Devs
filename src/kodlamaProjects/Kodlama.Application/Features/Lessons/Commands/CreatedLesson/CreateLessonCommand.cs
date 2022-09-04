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

namespace Kodlama.Application.Features.Lessons.Commands.CreatedLesson
{
    public partial class CreateLessonCommand:IRequest<CreatedLessonDto>
    {
        public string Name { get; set; }

        public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, CreatedLessonDto>
        {
            private readonly ILessonRepository _lessonRepository;
            private readonly IMapper _mapper;
            private readonly LessonBusinessRules _lessonBusinessRules;
            public CreateLessonCommandHandler(ILessonRepository lessonRepository, IMapper mapper, LessonBusinessRules lessonBusinessRules)
            {
                _lessonRepository = lessonRepository;
                _mapper = mapper;
                _lessonBusinessRules = lessonBusinessRules;
            }

            public async Task<CreatedLessonDto> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
            {
                await _lessonBusinessRules.LessonNameCanNotBeDuplicatedWhenInsert(request.Name);

                Lesson mappedLesson = _mapper.Map<Lesson>(request);
                Lesson createdLesson = await _lessonRepository.AddAsync(mappedLesson);
                CreatedLessonDto createdLessonDto=_mapper.Map<CreatedLessonDto>(createdLesson);

                return createdLessonDto;
            }
        }
    }
}
