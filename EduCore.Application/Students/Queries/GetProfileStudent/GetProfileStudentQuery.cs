using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Students.Queries.GetProfileStudent
{
    public sealed record GetProfileStudentQuery() : IQuery<StudentResponse>;
}
