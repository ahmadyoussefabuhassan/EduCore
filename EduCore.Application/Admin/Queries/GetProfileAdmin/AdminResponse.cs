using EduCore.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Admin.Queries.GetProfileAdmin
{
    internal sealed record AdminResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string FullName,
        string Email,
        string PhoneNumber,
        Genders Genders,
        string Address,
        string? ImageUrl,
        string roleName,
        DateTime CreatedAt
    );
}
