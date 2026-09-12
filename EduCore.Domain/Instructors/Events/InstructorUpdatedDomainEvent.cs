using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Instructors.Events
{
    public sealed record InstructorUpdatedDomainEvent(Guid Id, Specialization Specialization) : IDomainEvent;
}
