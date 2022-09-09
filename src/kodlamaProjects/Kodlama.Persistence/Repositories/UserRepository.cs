using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.Application.Services.Repositories;
using Kodlama.Persistence.Contexts;

namespace Kodlama.Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }

        public IList<OperationClaim> GetOperationClaims(User user)
        {
            var result = from OperationClaim in Context.OperationClaims
                         join UserOperationClaim in Context.UserOperationClaims
                         on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                         where UserOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };
            return result.ToList();
                    

        }
    }
}
