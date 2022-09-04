using Core.Persistence.Repositories;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using Kodlama.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Persistence.Repositories
{
    public class LessonRepository : EfRepositoryBase<Lesson, BaseDbContext>, ILessonRepository
    {
        public LessonRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
