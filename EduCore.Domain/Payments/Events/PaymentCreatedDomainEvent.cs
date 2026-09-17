using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Payments.Events
{
    public sealed record PaymentCreatedDomainEvent(Guid PaymentId) : IDomainEvent;

}
