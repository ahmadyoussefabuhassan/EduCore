using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Instructors.Commands.RegisterInstructor
{
    public sealed record RegisterInstructorCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string PhoneNumber,
        string Address,
        string Specialization
    ) : ICommand;
}
