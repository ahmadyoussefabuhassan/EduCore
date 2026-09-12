using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Courses.Events
{
    public sealed record CourseCompletedDomainEvent(Guid Id) : IDomainEvent;
}
