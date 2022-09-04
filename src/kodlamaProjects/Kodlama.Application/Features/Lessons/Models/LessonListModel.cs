using Core.Persistence.Paging;
using Kodlama.Application.Features.Lessons.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.Lessons.Models
{
    public class LessonListModel:BasePageableModel
    {
        public IList<LessonListDto> Items { get; set; }
    }
}
