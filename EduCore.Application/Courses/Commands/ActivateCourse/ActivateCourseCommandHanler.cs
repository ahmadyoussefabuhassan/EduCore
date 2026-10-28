using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Courses;

namespace EduCore.Application.Courses.Commands.ActivateCourse
{
    internal sealed class ActivateCourseCommandHanler : ICommandHandler<ActivateCourseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _courseRepository;

        public ActivateCourseCommandHanler(IUnitOfWork unitOfWork, ICourseRepository courseRepository)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }

        public async Task<Result<Guid>> Handle(ActivateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (course is null)
                return Result.Failure<Guid>(CourseErrors.NotFound);
            course.Activate();
            await _courseRepository.UpdateAsync(course, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(course.Id);
        }
    }
}
