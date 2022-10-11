using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries
{
    public class GetListUserOperationClaimByUserIdQuery : IRequest<UserOperationClaimListModel>
    {
        public int UserId { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListUserOperationClaimByUserIdQueryHandler : IRequestHandler<GetListUserOperationClaimByUserIdQuery, UserOperationClaimListModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public GetListUserOperationClaimByUserIdQueryHandler(
                IUserOperationClaimRepository userOperationClaimRepository,
                IMapper mapper
                )
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimByUserIdQuery request, CancellationToken cancellationToken)
            {
                var userOperationClaim = await _userOperationClaimRepository.GetListAsync(

                   predicate: x => x.UserId == request.UserId
                    );

                var userOperationClaimsMapped = _mapper.Map<UserOperationClaimListModel>(userOperationClaim);
                return userOperationClaimsMapped;
            }
        }
    }
}
