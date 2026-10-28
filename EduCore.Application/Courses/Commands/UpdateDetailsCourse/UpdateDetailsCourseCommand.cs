using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Courses.Commands.UpdateDetailsCourse
{
    public sealed record UpdateDetailsCourseCommand(
        Guid Id ,
        string Name,
        string Description,
        short MaximumStudents,
        Guid CategoryId
    ) : ICommand<Guid>;
}
