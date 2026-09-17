using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Transactions
{
    public static class TransactionErrors
    {
        public readonly static Error InvalidType = new Error(
            "Transaction.InvalidType",
            "نوع الحركة المالية غير مدعوم.");
    }
}
