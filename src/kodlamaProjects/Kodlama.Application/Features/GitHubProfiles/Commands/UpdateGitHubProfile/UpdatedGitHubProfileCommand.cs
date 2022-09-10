using AutoMapper;
using Kodlama.Application.Features.GitHubProfiles.Commands.CreatedGithubProfile;
using Kodlama.Application.Features.GitHubProfiles.Dtos;
using Kodlama.Application.Features.GitHubProfiles.Rules;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile
{
    public class UpdatedGitHubProfileCommand : IRequest<UpdatedGitHubProfileDto>
    {
        public int Id { get; set; }
        public string GitHubUrl { get; set; }

        public class UpdatedGitHubProfileCommandHandler : IRequestHandler<UpdatedGitHubProfileCommand, UpdatedGitHubProfileDto>
        {
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly GitHubProfileBussinesRules _gitHubProfileBussinesRules;

            public UpdatedGitHubProfileCommandHandler(IGitHubProfileRepository gitHubProfileRepository, IMapper mapper, IUserRepository userRepository, GitHubProfileBussinesRules gitHubProfileBussinesRules)
            {
                _gitHubProfileRepository = gitHubProfileRepository;
                _mapper = mapper;
                _userRepository = userRepository;
                _gitHubProfileBussinesRules = gitHubProfileBussinesRules;
            }

            public async Task<UpdatedGitHubProfileDto> Handle(UpdatedGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                //Bussines Rule
                GitHubProfile getGitHubProfile = await _gitHubProfileRepository.GetAsync(a => a.Id == request.Id);
                _gitHubProfileBussinesRules.GitHubProfileShouldExistWhenRequested(getGitHubProfile);
                getGitHubProfile.GitHubUrl = request.GitHubUrl;

                GitHubProfile updatedGitHubProfile = await _gitHubProfileRepository.UpdateAsync(getGitHubProfile);
                updatedGitHubProfile.User = await _userRepository.GetAsync(a => a.Id == updatedGitHubProfile.UserId);
                UpdatedGitHubProfileDto result = _mapper.Map<UpdatedGitHubProfileDto>(updatedGitHubProfile);

                return result;

            }
        }
    }
}
