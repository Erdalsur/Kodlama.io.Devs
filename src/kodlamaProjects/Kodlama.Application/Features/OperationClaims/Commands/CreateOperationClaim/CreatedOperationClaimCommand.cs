using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.Application.Features.OperationClaims.Dtos;
using Kodlama.Application.Features.OperationClaims.Rules;
using Kodlama.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kodlama.Application.Features.OperationClaims.Constants.OperationClaims;
using static Kodlama.Domain.Constants.OperationClaims;

namespace Kodlama.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => new[] { Admin, OperationClaimAdd };

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenInserted(request.Name);

                OperationClaim mappedOperationClaim = new() { Name = request.Name };
                OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(mappedOperationClaim);
                CreatedOperationClaimDto createdOperationClaimDto = new() { Id = createdOperationClaim.Id, Name = createdOperationClaim.Name };
                return createdOperationClaimDto;
            }
        }
    }
}
