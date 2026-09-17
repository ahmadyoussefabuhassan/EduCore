using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Wallets.Events
{
    public sealed record WalletCreatedDomainEvent(Guid Id) : IDomainEvent;
}
