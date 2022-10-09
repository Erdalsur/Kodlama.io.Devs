using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.Application.Features.UserOperationClaims.Commnads.CreateUserOperationClaim;
using Kodlama.Application.Features.UserOperationClaims.Commnads.DeleteUserOperationClaim;
using Kodlama.Application.Features.UserOperationClaims.Commnads.UpdateUserOperationClaim;
using Kodlama.Application.Features.UserOperationClaims.Dtos;
using Kodlama.Application.Features.UserOperationClaims.Models;
using Kodlama.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>()
                .ForMember(a=>a.UserName, opt=>opt.MapFrom(m=>m.User.FirstName+" "+m.User.LastName))
                .ForMember(a=>a.OperationClaimName, opt=>opt.MapFrom(m=>m.OperationClaim.Name))
                .ReverseMap();
            CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>()
                .ForMember(a => a.UserName, opt => opt.MapFrom(m => m.User.FirstName + " " + m.User.LastName))
                .ForMember(a => a.OperationClaimName, opt => opt.MapFrom(m => m.OperationClaim.Name))
                .ReverseMap();
            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>()
                .ForMember(a => a.UserName, opt => opt.MapFrom(m => m.User.FirstName + " " + m.User.LastName))
                .ForMember(a => a.OperationClaimName, opt => opt.MapFrom(m => m.OperationClaim.Name))
                .ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, GetByIdUserOperationClaimsQuery>().ReverseMap();
            
            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimsListByUserModel>().ReverseMap();
            CreateMap<UserOperationClaim,ListByUserOperationClaimsDto>()
                .ForMember(a=>a.OperationClaimName, opt=>opt.MapFrom(m=>m.OperationClaim.Name))
                .ReverseMap();
        }
    }
}
