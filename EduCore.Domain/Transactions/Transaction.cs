using EduCore.Domain.Abstractions;
using EduCore.Domain.Shared;
using EduCore.Domain.Users;
using EduCore.Domain.Wallets;


namespace EduCore.Domain.Transactions
{
    public sealed class Transaction : Entity
    {
        private Transaction(Guid Id, Money amount, Description? description, TransactionType transactionType, Guid walletId, Guid performedByUserId) : base(Id)
        {
            Amount = amount;
            Description = description;
            TransactionType = transactionType;
            CreatedAt = DateTime.UtcNow;
            WalletId = walletId;
            PerformedByUserId = performedByUserId;
        }
        public Money Amount { get; private set; }
        public Description? Description { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid WalletId { get; private set; }
        public Guid PerformedByUserId { get; private set; }
        public Wallet Wallet { get; private set; } = null!;
        public User User { get; private set; } = null!;
        internal static Transaction Create(Money amount, Description? description, TransactionType transactionType, Guid walletId, Guid performedByUserId)
        {
            var transaction = new Transaction(Guid.NewGuid(), amount, description, transactionType, walletId, performedByUserId);
            return transaction;
        }

    }
}
