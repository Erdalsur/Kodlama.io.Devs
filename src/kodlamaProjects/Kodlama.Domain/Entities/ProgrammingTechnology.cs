using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Domain.Entities
{
    public class ProgrammingTechnology:Entity
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public virtual Lesson? Lesson { get; set; }

        public ProgrammingTechnology()
        {
        }

        public ProgrammingTechnology(int id,int lessonId,string name) : base(id)
        {
            Id = id;
            LessonId = lessonId;
            Name = name;
        }
    }
}
