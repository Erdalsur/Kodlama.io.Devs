using Core.Persistence.Repositories;
using Kodlama.Domain.Entities;

namespace Kodlama.Application.Services.Repositories
{
    public interface IProgrammingTechnologyRepository : IAsyncRepository<ProgrammingTechnology>, IRepository<ProgrammingTechnology>
    {

    }
}
