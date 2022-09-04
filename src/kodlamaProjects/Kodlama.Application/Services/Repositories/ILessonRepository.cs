using Core.Persistence.Repositories;
using Kodlama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Services.Repositories
{
    public interface ILessonRepository : IAsyncRepository<Lesson>, IRepository<Lesson>
    {

    }
}
