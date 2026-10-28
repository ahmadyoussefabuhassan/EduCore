using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Categories;

namespace EduCore.Application.Categories.Commands.DeleteCategory
{
    internal sealed class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id , cancellationToken);
            if(category is null)
                return Result.Failure(CategoryErrors.NotFound);
            if (await _categoryRepository.HasRelatedDataAsync(request.Id, cancellationToken))
                return Result.Failure(CategoryErrors.HasRelatedData);
            await _categoryRepository.DeleteAsync(category.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
