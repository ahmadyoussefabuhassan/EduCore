using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Wallets
{
    public static class WalletErrors
    {
        public static readonly Error NotFound = new Error(
            "Wallet.NotFound",
            "لم يتم العثور على محفظة المستخدم.");

        public static readonly Error WalletIsInactive = new Error(
            "Wallet.IsInactive",
            "عذراً، هذه المحفظة موقوفة ولا يمكن إجراء أي عمليات مالية عليها.");

        public static readonly Error InvalidAmount = new Error(
            "Wallet.InvalidAmount",
            "المبلغ المدخل غير صالح أو يساوي صفراً.");

        public static readonly Error InsufficientBalance = new Error(
            "Wallet.InsufficientBalance",
            "عذراً، رصيد المحفظة غير كافٍ لإتمام هذه العملية.");
    }
}