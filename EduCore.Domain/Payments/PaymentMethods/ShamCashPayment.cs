namespace EduCore.Domain.Payments.PaymentMethods
{
    public sealed class ShamCashPayment : IPaymentMethod
    {
        public string Method => "ShamCash";
        public bool RequiresAttachment => true;
    }
}
