using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyDynamic
{
    public class GetListProgrammingLanguageByDynamicQuery : IRequest<ProgrammingTechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingLanguageByDynamicQueryHandler : IRequestHandler<GetListProgrammingLanguageByDynamicQuery, ProgrammingTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;

            public GetListProgrammingLanguageByDynamicQueryHandler(IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository)
            {
                _mapper = mapper;
                _programmingTechnologyRepository = programmingTechnologyRepository;
            }

            public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingLanguageByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingTechnology> programmingTechnologies = await _programmingTechnologyRepository.GetListByDynamicAsync(request.Dynamic,include:
                    m => m.Include(i => i.Lesson),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                ProgrammingTechnologyListModel results = _mapper.Map<ProgrammingTechnologyListModel>(programmingTechnologies);

                return results;
            }
        }

    }
}
