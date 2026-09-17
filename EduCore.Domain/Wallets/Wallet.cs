using EduCore.Domain.Abstractions;
using EduCore.Domain.Shared;
using EduCore.Domain.Transactions;
using EduCore.Domain.Users;
using EduCore.Domain.Wallets.Events;

namespace EduCore.Domain.Wallets
{
    public sealed class Wallet : Entity
    {
        private Wallet(Guid Id, Currency currency, Guid userId) : base(Id)
        {
            Balance = Money.Zero(currency);
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
            UserId = userId;
        }
        public Money Balance { get; private set; } = null!;
        public bool IsActive { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;
        public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();
        public static Wallet Create(Guid Id, Currency currency, Guid userId)
        {
            var wallet = new Wallet(Id, currency, userId);
            wallet.RaiseDomainEvent(new WalletCreatedDomainEvent(wallet.Id));
            return wallet;
        }
        public Result Deposit(Money amount)
        {
            if (!IsActive)
                return Result.Failure(WalletErrors.WalletIsInactive);
            if (amount.IsZero() || amount.Amount < 0)
                return Result.Failure(WalletErrors.InvalidAmount);
            Balance = Balance + amount;
            UpdatedAt = DateTime.UtcNow;
            RaiseDomainEvent(new WalletDepositDomainEvent(Id));
            return Result.Success();
        }
        public Result Withdraw(Money amount)
        {
            if (!IsActive)
                return Result.Failure(WalletErrors.WalletIsInactive);
            if (amount.IsZero() || amount.Amount < 0)
                return Result.Failure(WalletErrors.InvalidAmount);
            if (Balance < amount)
                return Result.Failure(WalletErrors.InsufficientBalance);
            Balance = Balance - amount;
            UpdatedAt = DateTime.UtcNow;
            RaiseDomainEvent(new WalletWithdrawDomainEvent(Id));
            return Result.Success();
        }
    }
}
