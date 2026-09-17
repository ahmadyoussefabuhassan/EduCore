namespace EduCore.Domain.Payments.PaymentMethods
{
    public sealed class BankTransferPayment : IPaymentMethod
    {
        public string Method => "BankTransfer";
        public bool RequiresAttachment => true;
    }
}
