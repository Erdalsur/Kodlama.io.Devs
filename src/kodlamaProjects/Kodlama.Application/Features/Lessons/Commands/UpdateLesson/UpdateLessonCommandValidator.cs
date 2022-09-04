using FluentValidation;

namespace Kodlama.Application.Features.Lessons.Commands.UpdateLesson
{
    public class UpdateLessonCommandValidator : AbstractValidator<UpdatedLessonCommand>
    {
        public UpdateLessonCommandValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.Name).NotEmpty();
        }
    }
}
