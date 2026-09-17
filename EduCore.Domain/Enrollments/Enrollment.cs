using EduCore.Domain.Abstractions;
using EduCore.Domain.Certificates;
using EduCore.Domain.Courses;
using EduCore.Domain.Enrollments.Events;
using EduCore.Domain.Payments;
using EduCore.Domain.Students;

namespace EduCore.Domain.Enrollments
{
    public sealed class Enrollment : Entity
    {

        private Enrollment(Guid Id, EnrollmentStatus status, Guid studentId, Guid courseId) : base(Id)
        {
            Status = status;
            EnrollmentDate = DateTime.UtcNow;
            StudentId = studentId;
            CourseId = courseId;
        }
        public EnrollmentStatus Status { get; private set; }
        public DateTime EnrollmentDate { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set; }
        public Student Student { get; private set; } = null!;
        public Course Course { get; private set; } = null!;
        public Certificate? Certificate { get; private set; }
        public ICollection<Payment> Payments { get; private set; } = new List<Payment>();
        public static Enrollment Create(Guid studentId, Guid courseId)
        {
            var enrollment = new Enrollment(Guid.NewGuid(), EnrollmentStatus.Pending, studentId, courseId);
            enrollment.RaiseDomainEvent(new EnrollmentCreatedDomainEvent(enrollment.Id));
            return enrollment;
        }
        public Result Activate()
        {
            if (Status != EnrollmentStatus.Pending)
                return Result.Failure(EnrollmentErrors.NotPending);
            Status = EnrollmentStatus.Active;
            RaiseDomainEvent(new EnrollmentActivatedDomainEvent(Id));
            return Result.Success();
        }
        public Result Complete()
        {
            if (Status != EnrollmentStatus.Active)
                return Result.Failure(EnrollmentErrors.NotActive);
            Status = EnrollmentStatus.Completed;
            RaiseDomainEvent(new EnrollmentCompletedDomainEvent(Id));
            return Result.Success();
        }
        public Result Cancel()
        {
            if (Status == EnrollmentStatus.Completed)
                return Result.Failure(EnrollmentErrors.CannotCancelCompleted);
            Status = EnrollmentStatus.Cancelled;
            RaiseDomainEvent(new EnrollmentCancelledDomainEvent(Id));
            return Result.Success();
        }
    }
}
