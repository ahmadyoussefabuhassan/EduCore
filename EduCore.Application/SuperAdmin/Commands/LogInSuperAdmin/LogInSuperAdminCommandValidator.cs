using FluentValidation;

namespace EduCore.Application.SuperAdmin.Commands.LogInSuperAdmin
{
    internal sealed class LogInSuperAdminCommandValidator : AbstractValidator<LogInSuperAdminCommand>
    {
        public LogInSuperAdminCommandValidator()
        {
            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("البريد الإلكتروني مطلوب")
                .EmailAddress().WithMessage("البريد الإلكتروني غير صالح");
            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("كلمة المرور مطلوبة")
                .MinimumLength(6).WithMessage("كلمة المرور يجب أن تكون على الأقل 6 أحرف");
        }
    }
}
