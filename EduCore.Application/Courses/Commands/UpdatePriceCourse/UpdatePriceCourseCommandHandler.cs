using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Courses;
using EduCore.Domain.Shared;

namespace EduCore.Application.Courses.Commands.UpdatePriceCourse
{
    internal sealed class UpdatePriceCourseCommandHandler : ICommandHandler<UpdatePriceCourseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _courseRepository;

        public UpdatePriceCourseCommandHandler(IUnitOfWork unitOfWork, ICourseRepository courseRepository)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }

        public async Task<Result<Guid>> Handle(UpdatePriceCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id, cancellationToken);
            if(course is null)
                return Result.Failure<Guid>(CourseErrors.NotFound);
            var currency = Currency.FromCode(request.Currency);
            course.UpdatePrice(new Money(request.Amount, currency));
            await _courseRepository.UpdateAsync(course, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(course.Id);
        }
    }
}
