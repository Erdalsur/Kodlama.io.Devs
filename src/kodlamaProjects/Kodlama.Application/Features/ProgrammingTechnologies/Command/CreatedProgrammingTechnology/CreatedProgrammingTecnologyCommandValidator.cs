using FluentValidation;

namespace Kodlama.Application.Features.ProgrammingTechnologies.Command.CreatedProgrammingTechnology
{
    public class CreatedProgrammingTecnologyCommandValidator : AbstractValidator<CreatedProgrammingTechnologyCommand>
    {
        public CreatedProgrammingTecnologyCommandValidator()
        {
            RuleFor(a => a.LessonId).NotEmpty();
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Name).MinimumLength(2);
        }
    }
}
