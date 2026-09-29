using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Admin.Commands.RegisterAdmin
{
    public sealed record RegisterAdminCommand(    
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string PhoneNumber,
        string Address
    ) : ICommand;
}
