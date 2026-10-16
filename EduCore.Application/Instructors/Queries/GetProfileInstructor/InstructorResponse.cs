using EduCore.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Instructors.Queries.GetProfileInstructor
{
    internal sealed record InstructorResponse(
        string FirstName,
        string LastName,
        string FullName,
        string Email,
        string PhoneNumber,
        Genders Genders,
        string Address,
        string? ImageUrl,
        string Specialization,
        DateTime CreatedAt
    );
}
