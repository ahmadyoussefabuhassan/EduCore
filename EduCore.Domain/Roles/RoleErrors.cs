using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Roles
{
    public static class RoleErrors
    {
        public static readonly Error NotFound = new Error(
            "Role.NotFound",
            "دور الصلاحية المطلوب غير موجود.");

        public static readonly Error AlreadyExists = new Error(
            "Role.AlreadyExists",
            "دور الصلاحية موجود مسبقاً.");
    }
}
