using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Students.Commands.UpdateProfileStudent
{
    public sealed record UpdateProfileStudentCommand(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        Genders Genders,
        string Address,
        IFormFile? ImageUrl
    ): ICommand<Guid>;
}
