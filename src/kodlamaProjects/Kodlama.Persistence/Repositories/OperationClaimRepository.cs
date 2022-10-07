using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.Application.Services.Repositories;
using Kodlama.Persistence.Contexts;

namespace Kodlama.Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
