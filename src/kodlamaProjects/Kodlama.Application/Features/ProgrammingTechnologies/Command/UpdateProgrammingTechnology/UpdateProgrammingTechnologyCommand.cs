using AutoMapper;
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

namespace Kodlama.Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommand:IRequest<UpdatedPrgrammingTechnologyDto>
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string Name { get; set; }
        public class UpdateProgrammingTechnologyCommandHandler:IRequestHandler<UpdateProgrammingTechnologyCommand,UpdatedPrgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public UpdateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<UpdatedPrgrammingTechnologyDto> Handle(UpdateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                _programmingTechnologyBusinessRules.ProgrammingTechnologyIdShouldExistWhenRequested(request.Id);
                _programmingTechnologyBusinessRules.ProgrammingTechnologyLessonIdShouldExistWhenRequested(request.LessonId);
                await _programmingTechnologyBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicatedWhenInsert(request.Name);

                ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology updateProgrammingTechnology = await _programmingTechnologyRepository.UpdateAsync(mappedProgrammingTechnology);
                UpdatedPrgrammingTechnologyDto result = _mapper.Map<UpdatedPrgrammingTechnologyDto>(updateProgrammingTechnology);

                return result;
            }
        }

    }
}
