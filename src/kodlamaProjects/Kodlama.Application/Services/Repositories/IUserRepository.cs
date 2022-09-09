using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.Application.Services.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
    {
        IList<OperationClaim> GetOperationClaims(User user);
    }
}
