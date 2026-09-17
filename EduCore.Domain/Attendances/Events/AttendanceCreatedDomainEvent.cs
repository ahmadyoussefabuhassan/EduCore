using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Attendances.Events
{
    public sealed record AttendanceCreatedDomainEvent(Guid Id) : IDomainEvent;
}
