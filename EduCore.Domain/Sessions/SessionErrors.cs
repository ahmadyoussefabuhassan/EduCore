using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Sessions
{
    public static class SessionErrors
    {
        public static readonly Error NotFound = new Error(
            "Session.NotFound",
            "لم يتم العثور على الجلسة التدريبية المطلوبة.");

        public static readonly Error InvalidTimeRange = new Error(
            "Session.InvalidTimeRange",
            "وقت بداية ونهاية الجلسة غير صالح.");

        public static readonly Error TimeConflict = new Error(
            "Session.TimeConflict",
            "يوجد تعارض في الموعد مع جلسة أخرى للمدرب.");
    }
}
