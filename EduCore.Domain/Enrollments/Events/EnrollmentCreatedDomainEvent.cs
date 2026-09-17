using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Enrollments.Events
{
    public sealed record EnrollmentCreatedDomainEvent(Guid EnrollmentId) : IDomainEvent;
}
