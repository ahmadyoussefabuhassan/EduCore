using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Students
{
    public static class StudentErrors
    {
        public static readonly Error NotFound = new Error(
            "Student.NotFound",
            "لم يتم العثور على بيانات الطالب المطلوبة.");

        public static readonly Error AlreadyExists = new Error(
            "Student.AlreadyExists",
            "بيانات الطالب مسجلة مسبقاً.");

        public static readonly Error Inactive = new Error(
            "Student.Inactive",
            "حساب الطالب غير نشط أو موقوف.");
    }
}
