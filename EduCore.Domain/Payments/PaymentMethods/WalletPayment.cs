namespace EduCore.Domain.Payments.PaymentMethods
{
    public sealed class WalletPayment : IPaymentMethod
    {
        public string Method => "Wallet";
        public bool RequiresAttachment => false;
    }
}
