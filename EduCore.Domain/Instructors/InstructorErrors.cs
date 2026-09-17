using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Instructors
{
    public static class InstructorErrors
    {
        public static readonly Error NotFound = new Error(
            "Instructor.NotFound",
            "لم يتم العثور على بيانات المدرب المطلوبة.");

        public static readonly Error SpecializationRequired = new Error(
            "Instructor.SpecializationRequired",
            "تخصص المدرب حقل إلزامي.");
    }
}
