using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Students.Events
{
    public sealed record StudentInActiveDomainEvent(Guid Id, StudentStatus Status) : IDomainEvent;
}
