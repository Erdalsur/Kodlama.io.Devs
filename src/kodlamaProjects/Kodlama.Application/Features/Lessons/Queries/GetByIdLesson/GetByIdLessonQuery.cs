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

namespace Kodlama.Application.Features.Lessons.Queries.GetByIdLesson
{
    public class GetByIdLessonQuery:IRequest<LessonGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdLessonQueryHandler:IRequestHandler<GetByIdLessonQuery,LessonGetByIdDto>
        {
            private readonly ILessonRepository _lessonRepository;
            private readonly IMapper _mapper;
            private readonly LessonBusinessRules _lessonBusinessRules;

            public GetByIdLessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper, LessonBusinessRules lessonBusinessRules)
            {
                _lessonRepository = lessonRepository;
                _mapper = mapper;
                _lessonBusinessRules = lessonBusinessRules;
            }

            public async Task<LessonGetByIdDto> Handle(GetByIdLessonQuery request, CancellationToken cancellationToken)
            {
                Lesson? lesson = await _lessonRepository.GetAsync(a => a.Id == request.Id);

                _lessonBusinessRules.LessonShouldExistWhenRequested(lesson);

                LessonGetByIdDto lessonGetByIdDto=_mapper.Map<LessonGetByIdDto>(lesson);
                return lessonGetByIdDto;

            }
        }
    }
}
