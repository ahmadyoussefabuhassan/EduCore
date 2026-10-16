using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Students.Commands.RegisterStudent
{
    public sealed record RegisterStudentCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string PhoneNumber,
        string Address
    ) :ICommand;
}
