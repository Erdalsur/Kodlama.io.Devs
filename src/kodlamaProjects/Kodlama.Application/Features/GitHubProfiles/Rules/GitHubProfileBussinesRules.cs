using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.GitHubProfiles.Rules
{
    public  class GitHubProfileBussinesRules
    {
        private IGitHubProfileRepository _gitHubProfileRepository;

        public GitHubProfileBussinesRules(IGitHubProfileRepository gitHubProfileRepository)
        {
            _gitHubProfileRepository = gitHubProfileRepository;
        }

        internal void GitHubProfileShouldExistWhenRequested(GitHubProfile? gitHubProfile)
        {
            if (gitHubProfile == null) throw new BusinessException("Request githubprofile does not exists.");
        }
    }
}
