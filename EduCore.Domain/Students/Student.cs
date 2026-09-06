using EduCore.Domain.Abstractions;
using EduCore.Domain.Users;

namespace EduCore.Domain.Students
{
    public sealed class Student : Entity
    {
        private Student() : base(Guid.Empty) { }
        private Student(Guid Id, StudentStatus status) : base(Id)
        {
            RegistrationDate = DateTime.UtcNow;
            Status = status;
        }
        public DateTime RegistrationDate { get; private set; }
        public StudentStatus Status { get; private set; }
        public User User { get; private set; } = null!;
        public static Student Create(Guid UserId)
        {
            var student = new Student(UserId , StudentStatus.Active);
            return student;
        }
        public void InActiveStudent()
            => Status = StudentStatus.InActived;
    }
}
