using AutoMapper;
using Kodlama.Application.Features.GitHubProfiles.Dtos;
using Kodlama.Application.Features.ProgrammingTechnologies.Command.CreatedProgrammingTechnology;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.GitHubProfiles.Commands.CreatedGithubProfile
{
    public class CreatedGitHubProfileCommand:IRequest<CreatedGitHubProfileDto>
    {
        public int UserId { get; set; }
        public string GitHubUrl { get; set; }

        public class CreatedGitHubProfileCommandHandler : IRequestHandler<CreatedGitHubProfileCommand, CreatedGitHubProfileDto>
        {
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;

            public CreatedGitHubProfileCommandHandler(IGitHubProfileRepository gitHubProfileRepository, IMapper mapper, IUserRepository userRepository)
            {
                _gitHubProfileRepository = gitHubProfileRepository;
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<CreatedGitHubProfileDto> Handle(CreatedGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                //Bussines Rule

                GitHubProfile mappedGitHubProfile=_mapper.Map<GitHubProfile>(request);
                GitHubProfile createdGitHubProfile = await _gitHubProfileRepository.AddAsync(mappedGitHubProfile);
                createdGitHubProfile.User = await _userRepository.GetAsync(a => a.Id == createdGitHubProfile.UserId);
                CreatedGitHubProfileDto result = _mapper.Map<CreatedGitHubProfileDto>(createdGitHubProfile);

                return result;
                
            }
        }
    }
}
