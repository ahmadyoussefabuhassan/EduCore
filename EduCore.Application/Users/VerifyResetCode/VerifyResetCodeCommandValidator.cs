using FluentValidation;

namespace EduCore.Application.Users.VerifyResetCode
{
    internal sealed class VerifyResetCodeCommandValidator : AbstractValidator<VerifyResetCodeCommand>
    {
        public VerifyResetCodeCommandValidator()
        {
            RuleFor(command => command.Code)
                .NotEmpty().WithMessage("الرمز تحقق مطلوب")
                .MinimumLength(6).WithMessage(" الرمز تحقق غير صالح");
        }
    }
}
