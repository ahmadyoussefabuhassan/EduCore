using EduCore.Domain.Abstractions;
using EduCore.Domain.Shared;
using EduCore.Domain.Wallets;

namespace EduCore.Domain.Transactions
{
    public sealed class TransactionWalletDomainService
    {

        public Result<Transaction> ProcessTransaction(Wallet wallet, Money amount, TransactionType type, Description description, Guid performedByUserId)
        {
            if (wallet is null)
                return Result.Failure<Transaction>(WalletErrors.NotFound);
            var WalletResult = type switch
            {
                TransactionType.Deposit => wallet.Deposit(amount),
                TransactionType.Withdrawal or TransactionType.Payment => wallet.Withdraw(amount),
                TransactionType.Refund => wallet.Deposit(amount),
                _ => Result.Failure<Transaction>(TransactionErrors.InvalidType),
            };
            if (WalletResult.IsFailure)
                return Result.Failure<Transaction>(WalletResult.Error);
            var transaction = Transaction.Create(
                amount,
                description,
                type,
                wallet.Id,
                performedByUserId
            );
            return Result.Success(transaction);
        }
    }
}
