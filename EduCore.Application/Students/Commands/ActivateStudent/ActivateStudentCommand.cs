using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Students.Commands.ActivateStudent
{
    public sealed record ActivateStudentCommand(Guid Id) : ICommand<bool>;
}
