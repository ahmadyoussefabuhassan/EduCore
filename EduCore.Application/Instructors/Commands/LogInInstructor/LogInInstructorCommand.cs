using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Models;

namespace EduCore.Application.Instructors.Commands.LogInInstructor
{
    public sealed record LogInInstructorCommand(
        string Email,
        string Password
    ) : ICommand<AuthenticationResponse>;
}
