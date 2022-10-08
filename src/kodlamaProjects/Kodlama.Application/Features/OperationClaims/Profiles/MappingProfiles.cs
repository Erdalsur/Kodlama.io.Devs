using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.Application.Features.OperationClaims.Dtos;
using Kodlama.Application.Features.OperationClaims.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimGetByIdDto>().ReverseMap();
        }
    }
}
