using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Instructors.Queries.GetCountInstructor
{
    public sealed record GetCountInstructorQuery() : IQuery<int>;
}
