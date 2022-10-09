using AutoMapper;
using Core.Security.Entities;
using Kodlama.Application.Features.UserOperationClaims.Dtos;
using Kodlama.Application.Features.UserOperationClaims.Rules;
using Kodlama.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.UserOperationClaims.Commnads.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommand:IRequest<UpdatedUserOperationClaimDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.RegisteredUser(request.UserId);
                await _userOperationClaimBusinessRules.RegisteredOperationClaim(request.OperationClaimId);

                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);
                UpdatedUserOperationClaimDto updatedUserOperationClaimDto=_mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);
                return updatedUserOperationClaimDto;
            }
        }
    }
}
