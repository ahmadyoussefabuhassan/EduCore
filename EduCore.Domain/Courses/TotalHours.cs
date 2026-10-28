namespace EduCore.Domain.Courses
{
    public sealed record TotalHours
    {
        public short Value { get; init; }
        public TotalHours(short value)
        {
            if (value <= 0)
                throw new ArgumentException("Total hours cannot be negative.", nameof(value));
            Value = value;
        }
    }
}
