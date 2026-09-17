using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Enrollments
{
    public static class EnrollmentErrors
    {
        public static readonly Error NotFound = new Error(
     "Enrollment.NotFound",
     "لم يتم العثور على سجل التسجيل.");
        public static readonly Error NotPending = new Error(
         "Enrollment.NotPending",
         "سجل التسجيل ليس في حالة الانتظار.");

        public static readonly Error NotActive = new Error(
            "Enrollment.NotActive",
            "سجل التسجيل ليس نشطاً.");
        public static readonly Error CannotCancelCompleted = new Error(
            "Enrollment.CannotCancelCompleted",
            "لا يمكن إلغاء تسجيل مكتمل.");
    }
}
