using EduCore.Domain.Shared;
using FluentValidation;

namespace EduCore.Application.Courses.Commands.UpdatePriceCourse
{
    internal sealed class UpdatePriceCourseCommandValidator : AbstractValidator<UpdatePriceCourseCommand>
    {
        public UpdatePriceCourseCommandValidator()
        {
            RuleFor(command => command.Currency)
                .NotEmpty().WithMessage("رمز العملة إلزامي.")
                 .Must(code =>
                 {
                    try { Currency.FromCode(code); return true; }
                    catch { return false; }
                 }).WithMessage("رمز العملة غير مدعوم في النظام.");
            RuleFor(command => command.Amount)
                .GreaterThan(0).WithMessage("سعر الدورة يجب أن يكون أكبر من الصفر.");
        }
    }
}
