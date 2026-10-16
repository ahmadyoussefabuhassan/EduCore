using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Users.ChangePasswordResetCode
{
    public sealed record ChangePasswordResetCodeCommand(string Email,string Code , string Password) : ICommand;
}
