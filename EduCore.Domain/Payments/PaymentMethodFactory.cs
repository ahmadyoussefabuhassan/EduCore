using EduCore.Domain.Payments.PaymentMethods;

namespace EduCore.Domain.Payments
{
    public static class PaymentMethodFactory
    {
        public static IPaymentMethod Create(string methodName)
        {
            return methodName?.Trim().ToLowerInvariant() switch
            {
                "cash" => new CashPayment(),
                "banktransfer" => new BankTransferPayment(),
                "shamcash" => new ShamCashPayment(),
                "wallet" => new WalletPayment(),
                _ => throw new ArgumentException($"Invalid payment method: {methodName}")
            };
        }
    }
}
