using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.Application.Features.Lessons.Commands.CreatedLesson;
using Kodlama.Application.Features.Lessons.Commands.UpdateLesson;
using Kodlama.Application.Features.Lessons.Dtos;
using Kodlama.Application.Features.Lessons.Models;
using Kodlama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.Lessons.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Lesson, CreatedLessonDto>().ReverseMap();
            CreateMap<Lesson, CreateLessonCommand>().ReverseMap();
            CreateMap<IPaginate<Lesson>,LessonListModel>().ReverseMap();
            CreateMap<Lesson,LessonListDto>().ReverseMap();
            CreateMap<Lesson, LessonGetByIdDto>().ReverseMap();
            CreateMap<Lesson, UpdatedLessonDto>().ReverseMap();
            CreateMap<Lesson, UpdatedLessonCommand>().ReverseMap();
            CreateMap<Lesson, DeletedLessonDto>().ReverseMap();
        }
    }
}
