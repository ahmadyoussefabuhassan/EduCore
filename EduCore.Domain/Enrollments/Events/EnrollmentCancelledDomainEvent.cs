using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Enrollments.Events
{
    public sealed record EnrollmentCancelledDomainEvent(Guid EnrollmentId) : IDomainEvent;
}
