using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Certificates
{
    public static class CertificateErrors
    {
        public static readonly Error NotFound = new Error(
            "Certificate.NotFound",
            "الشهادة المطلوبة غير موجودة.");

        public static readonly Error AlreadyIssued = new Error(
            "Certificate.AlreadyIssued",
            "تم إصدار شهادة لهذا التسجيل مسبقاً.");

        public static readonly Error ConditionsNotMet = new Error(
            "Certificate.ConditionsNotMet",
            "لم يستوفِ الطالب شروط إصدار الشهادة (حضور غير كافٍ أو رسوم غير مسددة).");
    }
}
