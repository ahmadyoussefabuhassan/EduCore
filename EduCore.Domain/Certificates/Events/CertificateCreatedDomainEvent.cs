using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Certificates.Events
{
    public sealed record CertificateCreatedDomainEvent(Guid Id) : IDomainEvent;
}
