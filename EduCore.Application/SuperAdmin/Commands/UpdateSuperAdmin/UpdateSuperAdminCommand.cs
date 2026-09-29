using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.SuperAdmin.Commands.UpdateSuperAdmin
{
    public sealed record UpdateSuperAdminCommand(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        Genders Genders,
        string Address,
        IFormFile? ImageUrl
    ) : ICommand<Guid>;
}
