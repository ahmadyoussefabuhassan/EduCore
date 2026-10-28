using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Courses.Commands.ActivateCourse
{
    public sealed record ActivateCourseCommand(Guid Id) : ICommand<Guid>; 
}
