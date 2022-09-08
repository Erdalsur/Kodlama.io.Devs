using Core.Persistence.Repositories;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using Kodlama.Persistence.Contexts;

namespace Kodlama.Persistence.Repositories
{
    public class ProgrammingTechnologyRepository : EfRepositoryBase<ProgrammingTechnology, BaseDbContext>, IProgrammingTechnologyRepository
    {
        public ProgrammingTechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
