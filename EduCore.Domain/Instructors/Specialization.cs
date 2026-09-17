namespace EduCore.Domain.Instructors
{
    public sealed record Specialization
    {
        public string Value { get; init; }
        public Specialization(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Specialization cannot be empty.", nameof(value));
            Value = value;

        }
    }
}
