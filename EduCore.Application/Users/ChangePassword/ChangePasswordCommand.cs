using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Users.ChangePassword
{
    public sealed record ChangePasswordCommand(
        string OldPassword,
        string NewPassword,
        string CheckNewPassword
    ) : ICommand;
}
