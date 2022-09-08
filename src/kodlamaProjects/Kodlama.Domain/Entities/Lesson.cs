using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Domain.Entities
{
    public class Lesson:Entity
    {
        public Lesson() //Programlama Dili Olarak Değişecek
        {
        }

        public Lesson(int id,string name) : base(id)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }


    }
}
