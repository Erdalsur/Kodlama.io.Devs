using AutoMapper;
using Kodlama.Application.Features.GitHubProfiles.Commands.CreatedGithubProfile;
using Kodlama.Application.Features.GitHubProfiles.Commands.DeletedGitHubProfile;
using Kodlama.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile;
using Kodlama.Application.Features.GitHubProfiles.Dtos;
using Kodlama.Application.Features.GitHubProfiles.Queries.GetByUserIdGitHubProfile;
using Kodlama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.GitHubProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GitHubProfile, CreatedGitHubProfileDto>()
                .ForMember(a=>a.FullName, opt=> opt.MapFrom(m=>m.User.FirstName+' '+m.User.LastName))
                .ReverseMap();
            CreateMap<GitHubProfile, CreatedGitHubProfileCommand>().ReverseMap();
            CreateMap<GitHubProfile,DeletedGitHubProfileDto>()
                .ForMember(a => a.FullName, opt => opt.MapFrom(m => m.User.FirstName + ' ' + m.User.LastName))
                .ReverseMap();
            CreateMap<GitHubProfile, DeletedGitHubProfileCommand>().ReverseMap();
            CreateMap<GitHubProfile, UpdatedGitHubProfileDto>()
                .ForMember(a => a.FullName, opt => opt.MapFrom(m => m.User.FirstName + ' ' + m.User.LastName))
                .ReverseMap();
            CreateMap<GitHubProfile, UpdatedGitHubProfileCommand>().ReverseMap();

            CreateMap<GitHubProfile, GitHubProfileGetByUserIdDto>().ReverseMap();
            CreateMap<GitHubProfile, GetByUserIdGitHubProfileQuery>().ReverseMap();

        }
    }
}
