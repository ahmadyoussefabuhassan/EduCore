using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Categories.Queries.GetAllCategories
{
    public sealed record GetAllCategoriesQuery() : IQuery<IEnumerable<CategoryResponse>>;
}
