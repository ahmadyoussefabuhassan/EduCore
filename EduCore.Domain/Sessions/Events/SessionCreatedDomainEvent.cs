using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Sessions.Events
{
    public sealed record SessionCreatedDomainEvent(Guid Id) : IDomainEvent;
}
