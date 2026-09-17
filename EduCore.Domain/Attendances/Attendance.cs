using EduCore.Domain.Abstractions;
using EduCore.Domain.Attendances.Events;
using EduCore.Domain.Sessions;
using EduCore.Domain.Students;

namespace EduCore.Domain.Attendances
{
    public sealed class Attendance : Entity
    {
        private Attendance(Guid Id, AttendanceStatus status, Remarks? remarks, Guid studentId, Guid sessionId) : base(Id)
        {
            Status = status;
            Remarks = remarks;
            StudentId = studentId;
            SessionId = sessionId;
        }
        public AttendanceStatus Status { get; private set; }
        public Remarks? Remarks { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid SessionId { get; private set; }
        public Student Student { get; private set; } = null!;
        public Session Session { get; private set; } = null!;
        public static Attendance Create(AttendanceStatus status, Remarks? remarks, Guid studentId, Guid sessionId)
        {
            var attendance = new Attendance(Guid.NewGuid(), status, remarks, studentId, sessionId);
            attendance.RaiseDomainEvent(new AttendanceCreatedDomainEvent(attendance.Id));
            return attendance;
        }

    }
}
