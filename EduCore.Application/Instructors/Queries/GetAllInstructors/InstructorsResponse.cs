using EduCore.Domain.Users;

namespace EduCore.Application.Instructors.Queries.GetAllInstructors
{
    internal sealed record InstructorsResponse(
        Guid Id,
        string FullName,
        string Email,
        string PhoneNumber,
        Genders Genders,
        string Specialization,
        string RoleName,
        DateTime CreatedAt
    );
}
