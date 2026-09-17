using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Notifications
{
    public static class NotificationErrors
    {
        public static readonly Error NotFound = new Error(
            "Notification.NotFound",
            "الإشعار المطلوب غير موجود.");
    }
}
