using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Categories.Queries.GetByIdCategory
{
    public sealed record GetByIdCategoryCommand(Guid Id) : IQuery<CategoryResponse>;
}
