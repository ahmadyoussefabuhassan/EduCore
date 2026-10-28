using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Categories;

namespace EduCore.Application.Categories.Queries.GetAllCategories
{
    internal sealed class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery,IEnumerable<CategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<IEnumerable<CategoryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync(cancellationToken);
            if(!categories.Any())
                return Result.Success(Enumerable.Empty<CategoryResponse>());
            var response = categories.Select(category => new CategoryResponse
            (
                category.Id,
                category.Name.Value
            ));
            return Result.Success(response);
        }
    }
}
