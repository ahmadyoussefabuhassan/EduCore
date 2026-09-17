namespace EduCore.Domain.Payments.PaymentMethods
{
    public sealed class CashPayment : IPaymentMethod
    {
        public string Method => "Cash";

        public bool RequiresAttachment => true;
    }
}
