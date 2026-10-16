using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Users.ForgotPassword
{
    public sealed record SendResetCodeCommand(string Email) : ICommand;
}
