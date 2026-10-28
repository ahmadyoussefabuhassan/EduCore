using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Courses.Commands.UpdateDateRangeCourse
{
    public sealed record UpdateDateRangeCourseCommand(
        Guid Id,
        DateOnly? StartDate,
        DateOnly? EndDate
    ) : ICommand<Guid>; 
}
