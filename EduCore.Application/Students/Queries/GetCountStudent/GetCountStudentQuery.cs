using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Students.Queries.GetCountStudent
{
    public sealed record GetCountStudentQuery() : IQuery<int>;
}
