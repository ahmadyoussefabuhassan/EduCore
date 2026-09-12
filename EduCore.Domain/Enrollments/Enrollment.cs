using EduCore.Domain.Abstractions;
using EduCore.Domain.Courses;
using EduCore.Domain.Students;

namespace EduCore.Domain.Enrollments
{
    public sealed class Enrollment : Entity
    {
        private Enrollment() : base(Guid.Empty)
        {
        }
        private Enrollment(Guid Id, EnrollmentStatus status,  Guid studentId, Guid courseId) : base(Id)
        {
            Status = status;
            EnrollmentDate = DateTime.UtcNow;
            StudentId = studentId;
            CourseId = courseId;
        }
        public EnrollmentStatus Status { get; private set; }
        public DateTime EnrollmentDate { get; private set; }
        public Guid StudentId { get; private set; }
        public Student Student { get; private set; } = null!;
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; } = null!;
        public static Enrollment Create( Guid studentId, Guid courseId)
        {
            var enrollment = new Enrollment(Guid.NewGuid(), EnrollmentStatus.Pending, studentId, courseId);
            return enrollment;
        }


    }
}
