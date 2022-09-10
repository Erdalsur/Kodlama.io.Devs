using AutoMapper;
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

namespace Kodlama.Application.Features.GitHubProfiles.Queries.GetByUserIdGitHubProfile
{
    public class GetByUserIdGitHubProfileQuery:IRequest<GitHubProfileGetByUserIdDto>
    {
        public int UserId { get; set; }

        public class GetByUserIdGitHubProfileQueryHandler : IRequestHandler<GetByUserIdGitHubProfileQuery, GitHubProfileGetByUserIdDto>
        {
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly IMapper _mapper;
            private readonly GitHubProfileBussinesRules _gitHubProfileBussinesRules;

            public GetByUserIdGitHubProfileQueryHandler(IGitHubProfileRepository gitHubProfileRepository, IMapper mapper, GitHubProfileBussinesRules gitHubProfileBussinesRules)
            {
                _gitHubProfileRepository = gitHubProfileRepository;
                _mapper = mapper;
                _gitHubProfileBussinesRules = gitHubProfileBussinesRules;
            }

            public async Task<GitHubProfileGetByUserIdDto> Handle(GetByUserIdGitHubProfileQuery request, CancellationToken cancellationToken)
            {
                GitHubProfile gitHubProfile = await _gitHubProfileRepository.GetAsync(a => a.UserId == request.UserId);
                _gitHubProfileBussinesRules.GitHubProfileShouldExistWhenRequested(gitHubProfile);

                GitHubProfileGetByUserIdDto result = _mapper.Map<GitHubProfileGetByUserIdDto>(gitHubProfile);
                return result;
                
            }
        }
    }
}
