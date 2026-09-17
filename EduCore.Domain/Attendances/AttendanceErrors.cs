using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Attendances
{
    public static class AttendanceErrors
    {
        public static readonly Error NotFound = new Error(
            "Attendance.NotFound",
            "سجل الحضور غير موجود.");

        public static readonly Error AlreadyRecorded = new Error(
            "Attendance.AlreadyRecorded",
            "تم تسجيل حضور هذا الطالب مسبقاً لهذه الجلسة.");
    }
}
