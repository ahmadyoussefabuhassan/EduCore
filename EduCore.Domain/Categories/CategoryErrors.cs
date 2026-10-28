using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Categories
{
    public static class CategoryErrors
    {
        public static readonly Error NotFound = new Error(
            "Category.NotFound",
            "التصنيف أو القسم المطلوب غير موجود.");

        public static readonly Error AlreadyExists = new Error(
            "Category.AlreadyExists",
            "اسم التصنيف موجود مسبقاً.");
        public static readonly Error HasRelatedData = new Error(
                "Category.HasRelatedData",
                "لا يمكن حذف التصنيف لأنه مرتبط ببيانات أخرى.");
    }
}
