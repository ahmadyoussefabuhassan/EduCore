using FluentValidation;

namespace EduCore.Application.Courses.Commands.UpdateDetailsCourse
{
    internal sealed class UpdateDetailsCourseCommandValidator : AbstractValidator<UpdateDetailsCourseCommand>
    {
        public UpdateDetailsCourseCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("اسم الدورة التدريبية إلزامي.")
                .MaximumLength(30).WithMessage("اسم الدورة يجب ألا يتجاوز 30 حرفاً.");
            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("وصف الدورة إلزامي.")
                .MaximumLength(255).WithMessage("وصف الدورة يجب ألا يتجاوز 255 حرفاً.");
            RuleFor(command => command.MaximumStudents)
                .GreaterThan((short)0).WithMessage("الحد الأقصى للطلاب يجب أن يكون أكبر من الصفر.");
            RuleFor(command => command.CategoryId)
                    .NotEmpty().WithMessage("معرف التصنيف (Category) إلزامي.");
        }
    }
}
