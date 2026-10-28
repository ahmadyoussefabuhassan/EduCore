using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Categories.Commands.AddCategory
{
    public sealed record AddCategoryCommand(string Name) : ICommand<Guid>;
}
