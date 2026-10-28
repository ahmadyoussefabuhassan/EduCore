using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Categories.Commands.DeleteCategory
{
    public sealed record DeleteCategoryCommand(Guid Id) : ICommand;
}
