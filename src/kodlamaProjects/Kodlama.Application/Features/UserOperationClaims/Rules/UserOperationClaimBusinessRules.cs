using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public UserOperationClaimBusinessRules(IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task RegisteredUser(int userId)
        {
            User? user = await _userRepository.GetAsync(a=>a.Id==userId);
            if (user == null) throw new BusinessException("Not registered user.");
        }

        public async Task RegisteredOperationClaim(int id)
        {
            OperationClaim? operationClaim= await _operationClaimRepository.GetAsync(a=>a.Id==id);
            if (operationClaim == null) throw new BusinessException("Not registered Operation Claim");
        }

        public async Task UserOperationClaimShouldExistWhenRequested(UserOperationClaim userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException("User Operation Claim Should Exist When Requested");
        }
    }
}
