using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kodlama.Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(a => a.Name == name);
            if (result.Items.Any()) throw new BusinessException("Operation Claim Name exits.");
        }

        public async Task OperationClaimShouldExists(int id)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(a => a.Id == id);
            if (operationClaim == null) throw new BusinessException("Operation Claim not exits.");
        }

        public async Task OperationClaimNameCannotBeRepeated(string name)
        {
            await OperationClaimNameCanNotBeDuplicatedWhenInserted(name);
        }
    }
}
