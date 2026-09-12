namespace EduCore.Domain.Courses
{
    public sealed record Description
    {
        public string Value { get; init; }
        public Description(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Description cannot be empty.", nameof(value));
            Value = value;
        }
    }
}
