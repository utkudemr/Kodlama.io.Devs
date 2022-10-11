using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
    {
        public String Name { get; set; }

        internal class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public CreateOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository,
 OperationClaimBusinessRules operationClaimBusinessRules
                )
            {
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;

                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimCanNotBeDuplicatedWhenInserted(request.Name);
                var claim = _mapper.Map<OperationClaim>(request);
                var createdClaim = await _operationClaimRepository.AddAsync(claim);
                CreatedOperationClaimDto createdOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(createdClaim);
                return createdOperationClaimDto;
            }
        }
    }
}
