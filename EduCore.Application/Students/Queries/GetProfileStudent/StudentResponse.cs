using EduCore.Domain.Students;
using EduCore.Domain.Users;

namespace EduCore.Application.Students.Queries.GetProfileStudent
{
    internal sealed record StudentResponse(
        string FirstName,
        string LastName,
        string FullName,
        string Email,
        string PhoneNumber,
        Genders Genders,
        string Address,
        string? ImageUrl,
        StudentStatus Status,
        DateTime CreatedAt,
        DateTime RegistrationDate
    );
}
