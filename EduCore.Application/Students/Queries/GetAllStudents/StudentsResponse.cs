using EduCore.Domain.Students;
using EduCore.Domain.Users;

namespace EduCore.Application.Students.Queries.GetAllStudents
{
    internal sealed record StudentsResponse(
        Guid Id,
        string FullName,
        string Email,
        string PhoneNumber,
        Genders Genders,
        StudentStatus Status,
        string RoleName,
        DateTime CreatedAt,
        DateTime RegistrationDate
    );
}
