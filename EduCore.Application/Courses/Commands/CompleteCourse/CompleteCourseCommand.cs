using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Courses.Commands.CompleteCourse
{
    public sealed record CompleteCourseCommand(Guid Id) : ICommand<Guid>;
}
