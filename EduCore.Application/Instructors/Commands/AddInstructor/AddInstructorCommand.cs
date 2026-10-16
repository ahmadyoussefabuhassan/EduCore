using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Instructors.Commands.AddInstructor
{
    public sealed record AddInstructorCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string PhoneNumber,
        string Address,
        string Specialization
    ) : ICommand;  
}
