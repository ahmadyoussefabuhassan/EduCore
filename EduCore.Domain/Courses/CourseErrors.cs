using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Courses
{
    public static class CourseErrors
    {
        public static readonly Error NotFound = new Error(
            "Course.NotFound",
            "لم يتم العثور على الدورة التدريبية المطلوبة.");

        public static readonly Error StartDateRequired = new Error(
            "Course.StartDateRequired",
            "لا يمكن تحديد تاريخ نهاية بدون تحديد تاريخ بداية للدورة.");

        public static readonly Error InvalidDateRange = new Error(
            "Course.InvalidDateRange",
            "تاريخ النهاية لا يمكن أن يكون أسبق من تاريخ البداية.");

        public static readonly Error CourseNotActive = new Error(
            "Course.NotActive",
            "عذراً، هذه الدورة التدريبية غير متاحة أو منتهية.");

        public static readonly Error CourseIsFull = new Error(
            "Course.IsFull",
            "عذراً، لقد وصلت الدورة إلى الحد الأقصى للطلاب ولا يمكن التسجيل فيها.");

        public static readonly Error AlreadyEnrolled = new Error(
            "Course.AlreadyEnrolled",
            "الطالب مسجل بالفعل في هذه الدورة التدريبية.");

        public static readonly Error DateRangeRequiredForStatus = new Error(
            "Course.DateRangeRequiredForStatus",
            "لا يمكن تغيير حالة الدورة إلى هذه المرحلة بدون تحديد نطاق تواريخ البداية والنهاية.");

        public static readonly Error PriceCannotBeZeroOrNull = new Error(
            "Course.PriceCannotBeZeroOrNull",
            "سعر الدورة لا يمكن أن يكون فارغاً أو يساوي صفراً.");
        public static readonly Error StatusAlreadyMatched = new Error(
            "Course.StatusAlreadyMatched",
            "الدورة التدريبية تحمل هذه الحالة بالفعل.");
        public static readonly Error CourseAlreadyPublished = new Error(
            "Course.CourseAlreadyPublished",
            "عذراً، هذه الدورة التدريبية منشورة مسبقاً.");

    }
}
