using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Instructors.Events
{
    public sealed record InstructorCreatedDomainEvent(Guid Id, Specialization Specialization) : IDomainEvent;
}
