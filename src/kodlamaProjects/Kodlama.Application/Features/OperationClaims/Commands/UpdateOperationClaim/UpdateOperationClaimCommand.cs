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

namespace Kodlama.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimShouldExists(request.Id);
                await _operationClaimBusinessRules.OperationClaimNameCannotBeRepeated(request.Name);

                OperationClaim mappedOperationClaim = new() {Id=request.Id, Name = request.Name };
                OperationClaim updatedOperationClaim = await _operationClaimRepository.AddAsync(mappedOperationClaim);
                UpdatedOperationClaimDto updatedOperationClaimDto = new() { Id = updatedOperationClaim.Id, Name = updatedOperationClaim.Name };
                return updatedOperationClaimDto;
            }
        }
    }
}
