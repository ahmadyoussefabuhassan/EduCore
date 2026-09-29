using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Instructors.Commands.UpdateProfileInstructor
{
    public sealed record UpdateProfileInstructorCommand(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        Genders Genders,
        string Address,
        IFormFile? ImageUrl,
        string Specialization
    ) : ICommand<Guid>;
}
