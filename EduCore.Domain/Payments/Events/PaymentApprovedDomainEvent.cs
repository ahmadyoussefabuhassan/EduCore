using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Payments.Events
{
    public sealed record PaymentApprovedDomainEvent(Guid PaymentId) : IDomainEvent;

}
