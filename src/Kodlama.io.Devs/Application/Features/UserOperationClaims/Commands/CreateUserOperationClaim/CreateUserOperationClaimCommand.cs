using Application.Features.OperationClaims.Rules;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
        {

            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public CreateUserOperationClaimCommandHandler(UserBusinessRules userBusinessRules,IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules, IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _operationClaimBusinessRules = operationClaimBusinessRules;
                _userBusinessRules = userBusinessRules;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {

                var userOperationClaim = await _userOperationClaimBusinessRules.CheckOperationClaim(request.OperationClaimId);
                _operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(userOperationClaim);
                var user = await _userBusinessRules.GetUser(request.UserId);
                _userBusinessRules.UserShouldExistWhenRequested(user);

                var userOperationClaimMapped = _mapper.Map<UserOperationClaim>(request);
                var createdUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaimMapped);
                var operationClaimResult = _mapper.Map<CreatedUserOperationClaimDto>(createdUserOperationClaim);
                return operationClaimResult;

            }
        }
    }
}
