using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Wallets.Events
{
    public sealed record WalletDepositDomainEvent(Guid Id) : IDomainEvent;
}
