using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.Application.Services.Repositories;
using Kodlama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.ProgrammingTechnologies.Rules
{
    
    public class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;

        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository programmingTechnologyRepository)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
        }

        public async Task ProgrammingTechnologyNameCanNotBeDuplicatedWhenInsert(string name)
        {
            IPaginate<ProgrammingTechnology> result = await _programmingTechnologyRepository.GetListAsync(a => a.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Technology name exists.");

        }

        public void ProgrammingTechnologyLessonIdShouldExistWhenRequested(int id)
        {
            if (id == null | id < 1) throw new BusinessException("Request LessonId does not exists.");
        }

        public void ProgrammingTechnologyShouldExistWhenRequested(ProgrammingTechnology programmingTechnology)
        {
            if (programmingTechnology == null) throw new BusinessException("Request programming technology does not exists.");
        }
        public void ProgrammingTechnologyIdShouldExistWhenRequested(int id)
        {
            if (id == null | id < 1) throw new BusinessException("Request id does not exists.");
        }



    }
}
