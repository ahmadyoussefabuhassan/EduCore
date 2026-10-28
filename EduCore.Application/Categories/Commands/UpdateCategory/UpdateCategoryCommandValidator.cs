using FluentValidation;

namespace EduCore.Application.Categories.Commands.UpdateCategory
{
    internal sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("اسم التصنيف مطلوب")
                .MaximumLength(100).WithMessage("اسم التصنيف لا يجب أن يتجاوز 100 حرف");
        }
    }
}
