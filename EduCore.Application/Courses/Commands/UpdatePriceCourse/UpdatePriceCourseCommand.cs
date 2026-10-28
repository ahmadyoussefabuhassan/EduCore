using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Courses.Commands.UpdatePriceCourse
{
    public sealed record UpdatePriceCourseCommand(
        Guid Id,
        string Currency,
        decimal Amount
    ) : ICommand<Guid>;
}
