using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Payments
{
    public static class PaymentErrors
    {
        public static readonly Error AttachmentRequired = new Error(
        "Payment.AttachmentRequired",
        "عذراً، هذه الطريقة تتطلب إرفاق صورة الإيصال أو سند الدفع.");

        public static readonly Error InvalidPaymentMethod = new Error(
            "Payment.InvalidPaymentMethod",
            "طريقة الدفع المختارة غير صالحة.");
    }
}

