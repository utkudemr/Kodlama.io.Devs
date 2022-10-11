using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimCanNotBeDuplicatedWhenInserted(string name)
        {
            var isExist = await _operationClaimRepository.GetAsync(a=>a.Name==name);

            if (isExist!=null) throw new BusinessException("Operation Claim Is Exist");
        }

        public async Task OperationClaimCanNotBeDuplicatedWhenUpdated(string name)
        {
            var isExist = await _operationClaimRepository.GetAsync(a => a.Name == name);

            if (isExist != null) throw new BusinessException("Operation Claim Is Exist");
        }

        public void OperationClaimShouldExistWhenRequested(OperationClaim? operationClaim)
        {
            if (operationClaim == null) throw new BusinessException("Requested Operation Claim does not exist");
        }
    }
}
