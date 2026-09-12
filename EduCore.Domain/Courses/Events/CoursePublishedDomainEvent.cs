using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Courses.Events
{
    public sealed record CoursePublishedDomainEvent(Guid Id) : IDomainEvent;
}
