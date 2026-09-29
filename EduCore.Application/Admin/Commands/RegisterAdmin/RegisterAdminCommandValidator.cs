using FluentValidation;

namespace EduCore.Application.Admin.Commands.RegisterAdmin
{
    internal sealed class RegisterAdminCommandValidator : AbstractValidator<RegisterAdminCommand>
    {
        public RegisterAdminCommandValidator()
        {
            RuleFor(command => command.FirstName)
                .NotEmpty().WithMessage("الاسم الاول مطلوب")
                .MaximumLength(100).WithMessage("الاسم الاول لا يجب أن يتجاوز 100 حرف");
            RuleFor(command => command.FirstName)
                .NotEmpty().WithMessage("الاسم الثاني مطلوب")
                .MaximumLength(100).WithMessage("الاسم الثاني لا يجب أن يتجاوز 100 حرف");
            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("البريد الإلكتروني مطلوب")
                .EmailAddress().WithMessage("البريد الإلكتروني غير صالح");
            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("كلمة المرور مطلوبة")
                .MinimumLength(6).WithMessage("كلمة المرور يجب أن تكون على الأقل 6 أحرف");
            RuleFor(command => command.PhoneNumber)
                .NotEmpty().WithMessage("رقم الهاتف مطلوب")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("رقم الهاتف غير صالح");
            RuleFor(command => command.Address)
                .NotEmpty().WithMessage("العنوان مطلوب")
                .MaximumLength(200).WithMessage("العنوان لا يجب أن يتجاوز 200 حرف");
        }
    }
}
