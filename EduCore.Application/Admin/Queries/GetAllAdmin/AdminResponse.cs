using EduCore.Domain.Users;

namespace EduCore.Application.Admin.Queries.GetAllAdmin
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
        string? ImageUrl
    );
}
