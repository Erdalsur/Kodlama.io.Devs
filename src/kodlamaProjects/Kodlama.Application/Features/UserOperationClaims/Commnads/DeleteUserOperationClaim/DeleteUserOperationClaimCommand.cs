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

namespace Kodlama.Application.Features.UserOperationClaims.Commnads.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand:IRequest<DeletedUserOperationClaimDto>
    {
        public int Id { get; set; }
        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim? deleteUserOperationClaim = await _userOperationClaimRepository.GetAsync(a => a.Id == request.Id);

                await _userOperationClaimBusinessRules.UserOperationClaimShouldExistWhenRequested(deleteUserOperationClaim);

                UserOperationClaim deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(deleteUserOperationClaim);
                DeletedUserOperationClaimDto deletedUserOperationClaimDto=_mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);
                return deletedUserOperationClaimDto;
            }
        }
    }
}
