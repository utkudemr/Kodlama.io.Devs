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

namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaimCommand
{
    public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimDto>
        {
            private readonly UserBusinessRules _userRules;
            private readonly OperationClaimBusinessRules _operationClaimRules;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public UpdateUserOperationClaimCommandHandler(UserOperationClaimBusinessRules userOperationClaimBusinessRules, IUserOperationClaimRepository userOperationClaimRepository, IUserOperationClaimRepository userClaimRepository, UserBusinessRules userRules, OperationClaimBusinessRules operationClaimRules, IMapper mapper)
            {

                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _userOperationClaimRepository = userOperationClaimRepository;
                _userRules = userRules;
                _operationClaimRules = operationClaimRules;
                _mapper = mapper;
            }

            public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var userOperationClaim= await _userOperationClaimBusinessRules.UserOperationClaimShouldExist(request.Id);
                await _userRules.UserShouldExist(request.UserId);
                await _userOperationClaimBusinessRules.CheckOperationClaim(request.OperationClaimId);

                userOperationClaim.UserId= request.UserId;
                userOperationClaim.OperationClaimId= request.OperationClaimId;
                var updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(userOperationClaim);
                var updatedUserOperationClaimDto = _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);
                return updatedUserOperationClaimDto;

            }
        }
    }
}
