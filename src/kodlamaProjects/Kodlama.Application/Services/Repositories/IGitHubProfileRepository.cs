using Core.Persistence.Repositories;
using Kodlama.Domain.Entities;

namespace Kodlama.Application.Services.Repositories
{
    public interface IGitHubProfileRepository : IAsyncRepository<GitHubProfile>, IRepository<GitHubProfile>
    {

    }
}
