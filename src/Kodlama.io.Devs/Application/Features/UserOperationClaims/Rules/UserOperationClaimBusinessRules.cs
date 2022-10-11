using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _operationClaimRepository = operationClaimRepository;
        }
        public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim? userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException("Requested User Operation Claim does not exist");
        }

        public async Task<OperationClaim> CheckOperationClaim(int Id)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(p => p.Id == Id);
            if (operationClaim == null) throw new BusinessException("Operation Claim exists.");
            return operationClaim;
        }
        public async Task<UserOperationClaim> UserOperationClaimShouldExist(int Id)
        {
            var userOperationClaim = await _userOperationClaimRepository.GetAsync(p => p.Id == Id);
            if (userOperationClaim == null) throw new BusinessException("User Operation Claim exists.");
            return userOperationClaim;
        }
    }
}
