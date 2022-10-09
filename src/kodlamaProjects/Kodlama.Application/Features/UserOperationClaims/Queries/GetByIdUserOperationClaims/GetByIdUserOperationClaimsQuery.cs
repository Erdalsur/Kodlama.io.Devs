using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.Application.Features.UserOperationClaims.Models;
using Kodlama.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaims
{
    public class GetByIdUserOperationClaimsQuery:IRequest<UserOperationClaimsListByUserModel>
    {
        public int UserId { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetByIdUserOperationClaimsQueryHandler : IRequestHandler<GetByIdUserOperationClaimsQuery, UserOperationClaimsListByUserModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public GetByIdUserOperationClaimsQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimsListByUserModel> Handle(GetByIdUserOperationClaimsQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(a => a.UserId == request.UserId,
                                                                    include: m=>m.Include(a=>a.User).Include(b=>b.OperationClaim),
                                                                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                UserOperationClaimsListByUserModel userOperationClaimsListByUserModel=_mapper.Map<UserOperationClaimsListByUserModel>(userOperationClaims);
                return userOperationClaimsListByUserModel;
                
            }
        }
    }
}
