using EduCore.Domain.Users;

namespace EduCore.Application.SuperAdmin.Queries.GetProfileSuperAdmin
{
    internal sealed record SuperAdminResponse(
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
