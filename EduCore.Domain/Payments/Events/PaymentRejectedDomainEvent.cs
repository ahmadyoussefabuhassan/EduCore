using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Payments.Events
{
    public sealed record PaymentRejectedDomainEvent(Guid PaymentId) : IDomainEvent;

}
