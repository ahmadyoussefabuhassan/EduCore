using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Courses.Events
{
    public sealed record CourseCancelledDomainEvent(Guid Id) : IDomainEvent;
}
