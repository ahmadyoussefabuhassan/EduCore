using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Categories;

namespace EduCore.Application.Categories.Commands.AddCategory
{
    internal sealed class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Guid>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            if(await _categoryRepository.IsNameUniqueAsync(new CategoryName(request.Name) , cancellationToken))
                return Result.Failure<Guid>(CategoryErrors.AlreadyExists);
            var category = Category.Create(new CategoryName(request.Name));
            await _categoryRepository.AddAsync(category , cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(category.Id);
        }
    }
}
