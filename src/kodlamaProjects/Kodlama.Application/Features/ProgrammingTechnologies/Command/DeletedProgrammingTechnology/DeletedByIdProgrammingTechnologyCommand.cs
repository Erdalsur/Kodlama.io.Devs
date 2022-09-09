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

namespace Kodlama.Application.Features.ProgrammingTechnologies.Command.DeletedProgrammingTechnology
{
    public class DeletedByIdProgrammingTechnologyCommand : IRequest<DeletedPrgrammingTechnologyDto>
    {
        public int Id { get; set; }

        public class DeletedByIdLessonCommandHandler : IRequestHandler<DeletedByIdProgrammingTechnologyCommand, DeletedPrgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public DeletedByIdLessonCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<DeletedPrgrammingTechnologyDto> Handle(DeletedByIdProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                _programmingTechnologyBusinessRules.ProgrammingTechnologyIdShouldExistWhenRequested(request.Id);
                ProgrammingTechnology? programmingTechnology = await _programmingTechnologyRepository.GetAsync(a => a.Id == request.Id);
                _programmingTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingTechnology);
                ProgrammingTechnology deletedProgrammingTechnology = await _programmingTechnologyRepository.DeleteAsync(programmingTechnology);
                DeletedPrgrammingTechnologyDto deletedPrgrammingTechnologyDto = _mapper.Map<DeletedPrgrammingTechnologyDto>(deletedProgrammingTechnology);
                return deletedPrgrammingTechnologyDto;

            }
        }
    }
}
