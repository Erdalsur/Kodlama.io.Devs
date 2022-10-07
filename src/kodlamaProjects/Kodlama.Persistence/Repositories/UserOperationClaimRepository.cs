using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.Application.Services.Repositories;
using Kodlama.Persistence.Contexts;

namespace Kodlama.Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
