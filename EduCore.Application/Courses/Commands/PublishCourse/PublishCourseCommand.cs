using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Courses.Commands.PublishCourse
{
    public sealed record PublishCourseCommand(Guid Id) : ICommand<Guid>;
}
