using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.Lessons.Rules
{
    public class LessonBusinessRules
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonBusinessRules(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task LessonNameCanNotBeDuplicatedWhenInsert(string name)
        {
            IPaginate<Lesson> result = await _lessonRepository.GetListAsync(a => a.Name == name);
            if (result.Items.Any()) throw new BusinessException("Lesson name exists.");

        }

        public void LessonShouldExistWhenRequested(Lesson lesson)
        {
            if(lesson==null) throw new BusinessException("Request lesson does not exists.");
        }
        public void LessonIdShouldExistWhenRequested(int id)
        {
            if (id == null | id < 1) throw new BusinessException("Request id does not exists.");
        }



    }
}
