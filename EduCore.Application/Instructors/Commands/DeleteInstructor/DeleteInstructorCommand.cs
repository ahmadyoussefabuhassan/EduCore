using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Instructors.Commands.DeleteInstructor
{
    public sealed record DeleteInstructorCommand(Guid Id) : ICommand;
}
