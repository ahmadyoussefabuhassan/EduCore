using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Students.Commands.InActivateStudent
{
    public sealed record InActivateStudentCommand(Guid Id) : ICommand<bool>;

}
