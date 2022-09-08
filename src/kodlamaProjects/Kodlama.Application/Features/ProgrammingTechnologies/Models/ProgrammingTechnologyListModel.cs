using Kodlama.Application.Features.ProgrammingTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.ProgrammingTechnologies.Models
{
    public class ProgrammingTechnologyListModel
    {
        public IList<ProgrammingTechnologyListDto> Items { get; set; }
    }
}
