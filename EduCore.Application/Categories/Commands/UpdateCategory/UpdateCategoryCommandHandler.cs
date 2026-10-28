using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Categories;

namespace EduCore.Application.Categories.Commands.UpdateCategory
{
    internal sealed class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if(category is null)
                return Result.Failure<Guid>(CategoryErrors.NotFound);
            if (await _categoryRepository.IsNameUniqueAsync(new CategoryName(request.Name), cancellationToken))
                return Result.Failure<Guid>(CategoryErrors.AlreadyExists);
            category.UpdateCategoryName(new CategoryName(request.Name));
            await _categoryRepository.UpdateAsync(category , cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(category.Id);
        }
    }
}
