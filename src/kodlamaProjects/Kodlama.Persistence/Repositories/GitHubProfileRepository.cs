using Core.Persistence.Repositories;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using Kodlama.Persistence.Contexts;

namespace Kodlama.Persistence.Repositories
{
    public class GitHubProfileRepository : EfRepositoryBase<GitHubProfile, BaseDbContext>, IGitHubProfileRepository
    {
        public GitHubProfileRepository(BaseDbContext context) : base(context)
        {
        }
        
    }
}
