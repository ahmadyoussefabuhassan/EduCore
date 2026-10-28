using FluentValidation;

namespace EduCore.Application.Categories.Commands.AddCategory
{
    internal sealed class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("اسم التصنيف مطلوب")
                .MaximumLength(100).WithMessage("اسم التصنيف لا يجب أن يتجاوز 100 حرف");
        }
    }
}
