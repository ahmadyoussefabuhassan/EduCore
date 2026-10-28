using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Courses.Commands.AddCourse
{
    public sealed record AddCourseCommand(
        string Name,
        string Description,
        string Currency,
        decimal Amount,
        short TotalHours,
        short MaximumStudents,
        DateOnly? StartDate,
        DateOnly? EndDate,
        Guid CategoryId
    ) : ICommand<Guid>;
}
