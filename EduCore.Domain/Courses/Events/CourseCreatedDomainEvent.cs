using EduCore.Domain.Abstractions;
using EduCore.Domain.Shared;

namespace EduCore.Domain.Courses.Events
{
    public sealed record CourseCreatedDomainEvent(Guid Id ) : IDomainEvent;
}
