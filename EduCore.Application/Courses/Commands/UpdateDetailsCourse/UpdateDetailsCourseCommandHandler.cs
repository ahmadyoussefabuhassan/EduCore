using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Categories;
using EduCore.Domain.Courses;

namespace EduCore.Application.Courses.Commands.UpdateDetailsCourse
{
    internal sealed class UpdateDetailsCourseCommandHandler :
        ICommandHandler<UpdateDetailsCourseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _courseRepository;
        private readonly ICategoryRepository _categoryRepository;
        public UpdateDetailsCourseCommandHandler(IUnitOfWork unitOfWork, ICourseRepository courseRepository, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Guid>> Handle(UpdateDetailsCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id,cancellationToken);
            if(course is null)
                return Result.Failure<Guid>(CourseErrors.NotFound);
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId,cancellationToken);
            if (category is null)
                return Result.Failure<Guid>(CategoryErrors.NotFound);
            course.UpdateDetails(
                new CourseName(request.Name),
                new Description(request.Description),
                new MaximumStudents(request.MaximumStudents),
                category.Id
            );
            await _courseRepository.UpdateAsync(course , cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(course.Id);


        }
    }
}
