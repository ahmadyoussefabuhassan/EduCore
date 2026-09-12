namespace EduCore.Domain.Courses
{
    public sealed record TotalHours
    {
        public int Value { get; init; }
        public TotalHours(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Total hours cannot be negative.", nameof(value));
            Value = value;
        }
    }
}
