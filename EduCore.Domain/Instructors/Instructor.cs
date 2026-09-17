using EduCore.Domain.Abstractions;
using EduCore.Domain.Courses;
using EduCore.Domain.Users;

namespace EduCore.Domain.Instructors
{
    public sealed class Instructor : Entity
    {
        private Instructor(Guid Id, Specialization specialization) : base(Id)
        {
            Specialization = specialization;
        }
        public Specialization Specialization { get; private set; }
        public User User { get; private set; } = null!;
        public ICollection<Course> Courses { get; private set; } = new List<Course>();
        public static Instructor Create(Guid UserId, Specialization specialization)
        {
            var instructor = new Instructor(UserId, specialization);
            instructor.RaiseDomainEvent(new Events.InstructorCreatedDomainEvent(instructor.Id, instructor.Specialization));
            return instructor;
        }
        public void UpdateInstructor(Specialization specialization)
        {
            Specialization = specialization;
            RaiseDomainEvent(new Events.InstructorUpdatedDomainEvent(Id, Specialization));
        }


    }
}
