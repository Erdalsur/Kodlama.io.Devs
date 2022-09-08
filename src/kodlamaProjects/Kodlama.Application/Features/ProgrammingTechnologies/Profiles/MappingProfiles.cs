using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingTechnology, ProgrammingTechnologyListDto>()
                .ForMember(a=>a.LessonName, opt=>opt.MapFrom(m=>m.Lesson.Name))
                .ReverseMap();
            CreateMap<IPaginate<ProgrammingTechnology>, ProgrammingTechnologyListModel>().ReverseMap();
        }
    }
}
