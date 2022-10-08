using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.Application.Features.OperationClaims.Models;
using Kodlama.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.OperationClaims.Queries.GetListOperationClaimByDynamic
{
    public class GetListOperationClaimByDynamicQuery:IRequest<OperationClaimListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest  PageRequest { get; set; }
        public class GetListOperationClaimByDynamicQueryHandler : IRequestHandler<GetListOperationClaimByDynamicQuery, OperationClaimListModel>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetListOperationClaimByDynamicQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<OperationClaimListModel> Handle(GetListOperationClaimByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListByDynamicAsync(request.Dynamic, 
                                                            index: request.PageRequest.Page, 
                                                            size: request.PageRequest.PageSize);
                OperationClaimListModel operationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);
                return operationClaimListModel;
            }
        }
    }
}
