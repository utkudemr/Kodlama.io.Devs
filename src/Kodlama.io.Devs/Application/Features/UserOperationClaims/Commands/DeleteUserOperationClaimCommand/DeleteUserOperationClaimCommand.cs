using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaimCommand
{
    public class DeleteUserOperationClaimCommand : IRequest<DeleteUserOperationClaimDto>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeleteUserOperationClaimDto>
        {

            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IUserOperationClaimRepository _claimRepository;

            public DeleteOperationClaimCommandHandler(IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IUserOperationClaimRepository claimRepository)
            {
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _claimRepository = claimRepository;
            }

            public async Task<DeleteUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var userClaimBeDeleted = await _userOperationClaimBusinessRules.UserOperationClaimShouldExist(request.Id);
                var deletedUserClaim = await _claimRepository.DeleteAsync(userClaimBeDeleted);
                var deletedUserOperationClaimDto = _mapper.Map<DeleteUserOperationClaimDto>(deletedUserClaim);
                return deletedUserOperationClaimDto;
            }
        }
    }
}
