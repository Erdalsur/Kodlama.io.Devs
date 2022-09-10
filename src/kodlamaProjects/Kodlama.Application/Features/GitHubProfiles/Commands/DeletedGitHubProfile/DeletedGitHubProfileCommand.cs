using AutoMapper;
using FluentValidation;
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

namespace Kodlama.Application.Features.GitHubProfiles.Commands.DeletedGitHubProfile
{
    public class DeletedGitHubProfileCommand : IRequest<DeletedGitHubProfileDto>
    {
        public int Id { get; set; }
        public class DeletedGitHubProfileCommandHandler : IRequestHandler<DeletedGitHubProfileCommand, DeletedGitHubProfileDto>
        {
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly GitHubProfileBussinesRules _gitHubProfileBussinesRules;

            public DeletedGitHubProfileCommandHandler(IGitHubProfileRepository gitHubProfileRepository, IMapper mapper, IUserRepository userRepository, GitHubProfileBussinesRules gitHubProfileBussinesRules)
            {
                _gitHubProfileRepository = gitHubProfileRepository;
                _mapper = mapper;
                _userRepository = userRepository;
                _gitHubProfileBussinesRules = gitHubProfileBussinesRules;
            }

            public async Task<DeletedGitHubProfileDto> Handle(DeletedGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                //Bussines Rule

                GitHubProfile getGitHubProfile = await _gitHubProfileRepository.GetAsync(a=>a.Id==request.Id);
                _gitHubProfileBussinesRules.GitHubProfileShouldExistWhenRequested(getGitHubProfile);
                GitHubProfile deletedGitHubProfile = await _gitHubProfileRepository.DeleteAsync(getGitHubProfile);
                deletedGitHubProfile.User = await _userRepository.GetAsync(a => a.Id == deletedGitHubProfile.UserId);
                DeletedGitHubProfileDto result = _mapper.Map<DeletedGitHubProfileDto>(deletedGitHubProfile);

                return result;

            }
        }
    }

    
}
