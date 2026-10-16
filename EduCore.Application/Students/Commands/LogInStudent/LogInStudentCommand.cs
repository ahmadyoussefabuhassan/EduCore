using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Models;

namespace EduCore.Application.Students.Commands.LogInStudent
{
    public sealed record LogInStudentCommand(string Email, string Password) : ICommand<AuthenticationResponse>;
}
