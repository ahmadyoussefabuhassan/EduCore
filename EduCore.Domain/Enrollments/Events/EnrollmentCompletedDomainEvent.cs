using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Enrollments.Events
{
    public sealed record EnrollmentCompletedDomainEvent(Guid EnrollmentId) : IDomainEvent;
}
