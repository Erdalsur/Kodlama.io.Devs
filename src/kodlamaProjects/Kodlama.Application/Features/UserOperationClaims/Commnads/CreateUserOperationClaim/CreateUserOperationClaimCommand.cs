using AutoMapper;
using Core.Security.Entities;
using Kodlama.Application.Features.UserOperationClaims.Dtos;
using Kodlama.Application.Features.UserOperationClaims.Rules;
using Kodlama.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.UserOperationClaims.Commnads.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand:IRequest<CreatedUserOperationClaimDto>
    {
        
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public CreateUserOperationClaimCommandHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _mapper = mapper;
                _userOperationClaimRepository = userOperationClaimRepository;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.RegisteredUser(request.UserId);
                await _userOperationClaimBusinessRules.RegisteredOperationClaim(request.OperationClaimId);

                UserOperationClaim newUserOperationClaim = new() { 
                    OperationClaimId=request.OperationClaimId,
                    UserId=request.UserId
                };
                UserOperationClaim userOperationClaim = await _userOperationClaimRepository.AddAsync(newUserOperationClaim);
                CreatedUserOperationClaimDto createdUserOperationClaimDto= _mapper.Map<CreatedUserOperationClaimDto>(userOperationClaim);

                return createdUserOperationClaimDto;
            }
        }
    }
}
