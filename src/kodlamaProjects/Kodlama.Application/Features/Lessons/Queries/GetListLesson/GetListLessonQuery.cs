using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.Application.Features.Lessons.Models;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.Lessons.Queries.GetListLesson
{
    public class GetListLessonQuery : IRequest<LessonListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListLessonQueryHandler:IRequestHandler<GetListLessonQuery,LessonListModel>
        {
            private readonly ILessonRepository _lessonRepository;
            private readonly IMapper _mapper;

            public GetListLessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
            {
                _lessonRepository = lessonRepository;
                _mapper = mapper;
            }

            public async Task<LessonListModel> Handle(GetListLessonQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Lesson> lessons = await _lessonRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                LessonListModel mappedLessonListModel = _mapper.Map<LessonListModel>(lessons);
                return mappedLessonListModel;
            }
        }
    }
}
