using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Courses.Events
{
    public sealed record CourseCreatedDomainEvent(Guid Id) : IDomainEvent;
}
