using EduCore.Domain.Abstractions;
using EduCore.Domain.Attendances;
using EduCore.Domain.Enrollments;
using EduCore.Domain.Students.Events;
using EduCore.Domain.Users;

namespace EduCore.Domain.Students
{
    public sealed class Student : Entity
    {
        private Student(Guid Id, StudentStatus status) : base(Id)
        {
            RegistrationDate = DateTime.UtcNow;
            Status = status;
        }
        public DateTime RegistrationDate { get; private set; }
        public StudentStatus Status { get; private set; }
        public User User { get; private set; } = null!;
        public ICollection<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();
        public ICollection<Attendance> Attendances { get; private set; } = new List<Attendance>();

        public static Student Create(Guid UserId)
        {
            var student = new Student(UserId, StudentStatus.Active);
            return student;
        }
        public void InActiveStudent()
        {
            Status = StudentStatus.InActived;
            RaiseDomainEvent(new StudentInActiveDomainEvent(Id, Status));
        }
        public void ActiveStudent()
        {
            Status = StudentStatus.Active;
            RaiseDomainEvent(new StudentActiveDomainEvent(Id, Status));
        }

    }
}
