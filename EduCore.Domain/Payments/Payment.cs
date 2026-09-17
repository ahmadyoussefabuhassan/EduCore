using EduCore.Domain.Abstractions;
using EduCore.Domain.Enrollments;
using EduCore.Domain.Payments.Events;
using EduCore.Domain.Shared;
using EduCore.Domain.Users;

namespace EduCore.Domain.Payments
{
    public sealed class Payment : Entity
    {
        private Payment(Guid Id, Money amount, IPaymentMethod paymentMethod, TransactionAttachmentUrl? attachmentUrl, PaymentStatus status) : base(Id)
        {
            Amount = amount;
            PaymentMethod = paymentMethod;
            AttachmentUrl = attachmentUrl;
            Status = status;
            PaymentDate = DateTime.UtcNow;
        }
        public Money Amount { get; private set; }
        public IPaymentMethod PaymentMethod { get; private set; }
        public TransactionAttachmentUrl? AttachmentUrl { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public Guid EnrollmentId { get; private set; }
        public Guid? ConfirmedById { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Enrollment Enrollment { get; private set; } = null!;
        public User User { get; private set; } = null!;
        public static Result<Payment> Create(Money amount, IPaymentMethod paymentMethod, TransactionAttachmentUrl? attachmentUrl)
        {
            if (paymentMethod.RequiresAttachment && string.IsNullOrWhiteSpace(attachmentUrl?.Value))
                return Result.Failure<Payment>(PaymentErrors.AttachmentRequired);
            var payment = new Payment(Guid.NewGuid(), amount, paymentMethod, attachmentUrl, PaymentStatus.Pending);
            payment.RaiseDomainEvent(new PaymentCreatedDomainEvent(payment.Id));
            return payment;
        }
        public Result Confirm(Guid adminId)
        {
            if (Status != PaymentStatus.Pending)
                return Result.Failure(PaymentErrors.InvalidPaymentMethod);
            ConfirmedById = adminId;
            Status = PaymentStatus.Approved;
            UpdatedAt = DateTime.UtcNow;
            RaiseDomainEvent(new PaymentApprovedDomainEvent(Id));
            return Result.Success();
        }
        public Result Reject(Guid adminId)
        {
            if (Status != PaymentStatus.Pending)
                return Result.Failure(PaymentErrors.InvalidPaymentMethod);
            ConfirmedById = adminId;
            Status = PaymentStatus.Rejected;
            UpdatedAt = DateTime.UtcNow;
            RaiseDomainEvent(new PaymentRejectedDomainEvent(Id));
            return Result.Success();
        }
    }
}
