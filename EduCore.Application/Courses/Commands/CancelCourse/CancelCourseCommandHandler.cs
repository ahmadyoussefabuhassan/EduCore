using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Courses;

namespace EduCore.Application.Courses.Commands.CancelCourse
{
    internal sealed class CancelCourseCommandHandler : ICommandHandler<CancelCourseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _courseRepository;

        public CancelCourseCommandHandler(IUnitOfWork unitOfWork, ICourseRepository courseRepository)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }

        public async Task<Result<Guid>> Handle(CancelCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (course is null)
                return Result.Failure<Guid>(CourseErrors.NotFound);
            course.Cancel();
            await _courseRepository.UpdateAsync(course, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(course.Id);
        }
    }
}
