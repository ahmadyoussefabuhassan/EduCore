using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Sessions.Events
{
    public sealed record SessionUpdateTimeDomainEvent(Guid Id) : IDomainEvent;
}
