using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Categories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> IsNameUniqueAsync(CategoryName name, CancellationToken cancellationToken = default);  
        Task<bool> HasRelatedDataAsync(Guid categoryId, CancellationToken cancellationToken = default);
    }
}
