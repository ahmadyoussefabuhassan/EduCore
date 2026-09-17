namespace EduCore.Domain.Payments
{
    public interface IPaymentMethod
    {
        string Method { get; }
        bool RequiresAttachment { get; }
    }
}
