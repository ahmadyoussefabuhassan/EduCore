using EduCore.Domain.Shared;
using FluentValidation;

namespace EduCore.Application.Courses.Commands.AddCourse
{
    internal sealed class AddCourseCommandValidator : AbstractValidator<AddCourseCommand>
    {
        public AddCourseCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("اسم الدورة التدريبية إلزامي.")
                .MaximumLength(30).WithMessage("اسم الدورة يجب ألا يتجاوز 30 حرفاً.");
            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("وصف الدورة إلزامي.")
                .MaximumLength(255).WithMessage("وصف الدورة يجب ألا يتجاوز 255 حرفاً.");
            RuleFor(command => command.Currency)
                .NotEmpty().WithMessage("رمز العملة إلزامي.")
                .Must(code =>
                {
                    try { Currency.FromCode(code); return true; }
                    catch { return false; }
                }).WithMessage("رمز العملة غير مدعوم في النظام.");

            RuleFor(command => command.Amount)
                .GreaterThan(0).WithMessage("سعر الدورة يجب أن يكون أكبر من الصفر.");
            RuleFor(command => command.TotalHours)
                .GreaterThan((short)0).WithMessage("إجمالي ساعات الدورة يجب أن يكون أكبر من الصفر.");
            RuleFor(command => command.MaximumStudents)
                .GreaterThan((short)0).WithMessage("الحد الأقصى للطلاب يجب أن يكون أكبر من الصفر.");
            RuleFor(command => command.StartDate)
                .NotEmpty().WithMessage("تاريخ البداية إلزامي.")
                .Must((command, startDate) => !command.EndDate.HasValue || startDate <= command.EndDate.Value)
                .WithMessage("تاريخ البداية لا يمكن أن يكون بعد تاريخ النهاية.");
            RuleFor(command => command.CategoryId)
                .NotEmpty().WithMessage("معرف التصنيف (Category) إلزامي.");

        }
    }
}
