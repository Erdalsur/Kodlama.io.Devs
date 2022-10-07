using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.Application.Services.Repositories;
using Kodlama.Persistence.Contexts;

namespace Kodlama.Persistence.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
