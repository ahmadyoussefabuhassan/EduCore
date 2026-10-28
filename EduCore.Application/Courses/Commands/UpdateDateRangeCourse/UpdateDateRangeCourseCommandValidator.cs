using FluentValidation;

namespace EduCore.Application.Courses.Commands.UpdateDateRangeCourse
{
    internal sealed class UpdateDateRangeCourseCommandValidator : AbstractValidator<UpdateDateRangeCourseCommand>
    {
        public UpdateDateRangeCourseCommandValidator()
        {
            RuleFor(command => command.StartDate)
                .NotEmpty().WithMessage("تاريخ البداية إلزامي.")
                .Must((command, startDate) => !command.EndDate.HasValue || startDate <= command.EndDate.Value)
                .WithMessage("تاريخ البداية لا يمكن أن يكون بعد تاريخ النهاية.");
        }
    }
}
