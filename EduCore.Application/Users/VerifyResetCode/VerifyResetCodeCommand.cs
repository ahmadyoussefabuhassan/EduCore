using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Users.VerifyResetCode
{
    public sealed record VerifyResetCodeCommand(string Email, string Code): ICommand; 
}
