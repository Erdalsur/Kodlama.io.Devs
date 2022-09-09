using FluentValidation;

namespace Kodlama.Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTecnologyCommandValidator : AbstractValidator<UpdateProgrammingTechnologyCommand>
    {
        public UpdateProgrammingTecnologyCommandValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.LessonId).NotEmpty();
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Name).MinimumLength(2);
        }
    }
}
