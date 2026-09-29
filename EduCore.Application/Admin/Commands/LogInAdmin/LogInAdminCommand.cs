using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Models;

namespace EduCore.Application.Admin.Commands.LogInAdmin
{
    public sealed record LogInAdminCommand(string Email, string Password) : ICommand<AuthenticationResponse>;
}
