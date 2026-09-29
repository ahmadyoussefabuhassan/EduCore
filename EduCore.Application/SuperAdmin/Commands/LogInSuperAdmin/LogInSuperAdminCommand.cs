using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Models;

namespace EduCore.Application.SuperAdmin.Commands.LogInSuperAdmin
{
    public sealed record LogInSuperAdminCommand(
        string Email , 
        string Password
    ) : ICommand<AuthenticationResponse>;
}
