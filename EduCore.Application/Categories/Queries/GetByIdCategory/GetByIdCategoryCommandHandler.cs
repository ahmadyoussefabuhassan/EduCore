using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Categories;

namespace EduCore.Application.Categories.Queries.GetByIdCategory
{
    internal sealed class GetByIdCategoryCommandHandler : IQueryHandler<GetByIdCategoryCommand, CategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetByIdCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<CategoryResponse>> Handle(GetByIdCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if(category is null)
                return Result.Failure<CategoryResponse>(CategoryErrors.NotFound);
            var response = new CategoryResponse(category.Name.Value);
            return Result.Success(response);
        }
    }
}
