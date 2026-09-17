using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Courses.Events
{
    public sealed record CourseActivatedDomainEvent(Guid Id) : IDomainEvent;
}
