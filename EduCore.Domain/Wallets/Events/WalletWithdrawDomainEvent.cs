using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Wallets.Events
{
    public sealed record WalletWithdrawDomainEvent(Guid Id): IDomainEvent;
}
