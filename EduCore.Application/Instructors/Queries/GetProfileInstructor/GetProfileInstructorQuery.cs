using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Instructors.Queries.GetProfileInstructor
{
    public sealed record GetProfileInstructorQuery() : IQuery<InstructorResponse>;
}
