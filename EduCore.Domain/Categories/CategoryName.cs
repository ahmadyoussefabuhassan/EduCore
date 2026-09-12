
namespace EduCore.Domain.Categories
{
    public sealed record CategoryName
    {
        public string Value { get; init; }
        public CategoryName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Category name cannot be empty.", nameof(value));
            Value = value;
        }
    }
}
