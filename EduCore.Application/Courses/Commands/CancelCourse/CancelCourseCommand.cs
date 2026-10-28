using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Courses.Commands.CancelCourse
{
    public sealed record CancelCourseCommand(Guid Id) : ICommand<Guid>;
}
