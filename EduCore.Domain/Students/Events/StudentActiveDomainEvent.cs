using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Students.Events
{
    public sealed record StudentActiveDomainEvent(Guid Id, StudentStatus Status) : IDomainEvent;
}
