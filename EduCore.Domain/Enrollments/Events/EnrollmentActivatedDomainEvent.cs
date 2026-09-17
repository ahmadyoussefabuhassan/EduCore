using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Enrollments.Events
{
    public sealed record EnrollmentActivatedDomainEvent(Guid EnrollmentId) : IDomainEvent;
}
