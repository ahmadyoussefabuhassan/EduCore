using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Courses;

namespace EduCore.Application.Courses.Commands.UpdateDateRangeCourse
{
    internal sealed class UpdateDateRangeCourseCommandHandler : ICommandHandler<UpdateDateRangeCourseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _courseRepository;

        public UpdateDateRangeCourseCommandHandler(IUnitOfWork unitOfWork, ICourseRepository courseRepository)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }

        public async Task<Result<Guid>> Handle(UpdateDateRangeCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id, cancellationToken);
            if(course is null)
                return Result.Failure<Guid>(CourseErrors.NotFound);
            var dete = DateRange.Create(request.StartDate, request.EndDate);
            course.UpdateDateRange(dete);
            await _courseRepository.UpdateAsync(course, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(course.Id);
        }
    }
}
