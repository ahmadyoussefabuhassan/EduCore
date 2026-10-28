using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Categories.Commands.UpdateCategory
{
    public sealed record UpdateCategoryCommand(Guid Id,string Name) : ICommand<Guid>;
}
