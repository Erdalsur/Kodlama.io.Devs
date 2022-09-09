using AutoMapper;
using Kodlama.Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnology;
using Kodlama.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.ProgrammingTechnologies.Command.CreatedProgrammingTechnology
{
    public class CreatedProgrammingTechnologyCommand : IRequest<CreatedPrgrammingTechnologyDto>
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public class CreatedProgrammingTechnologyCommandHandler : IRequestHandler<CreatedProgrammingTechnologyCommand, CreatedPrgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public CreatedProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<CreatedPrgrammingTechnologyDto> Handle(CreatedProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                _programmingTechnologyBusinessRules.ProgrammingTechnologyLessonIdShouldExistWhenRequested(request.LessonId);
                await _programmingTechnologyBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicatedWhenInsert(request.Name);

                ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology addProgrammingTechnology = await _programmingTechnologyRepository.AddAsync(mappedProgrammingTechnology);
                CreatedPrgrammingTechnologyDto result = _mapper.Map<CreatedPrgrammingTechnologyDto>(addProgrammingTechnology);

                return result;
            }
        }

    }
}
