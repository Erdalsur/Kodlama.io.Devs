using AutoMapper;
using Core.Security.Entities;
using Kodlama.Application.Features.AppAuthorizations.Commands.RegisterUser;
using Kodlama.Application.Features.AppAuthorizations.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.AppAuthorizations.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
        }
    }
}
