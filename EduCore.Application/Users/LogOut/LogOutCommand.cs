using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Users.LogOut
{
    public sealed record LogOutCommand(string refreshtoken) : ICommand;
}
