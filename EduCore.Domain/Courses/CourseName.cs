namespace EduCore.Domain.Courses
{
    public sealed record CourseName
    {
        public string Value { get; init; }
        public CourseName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Course name cannot be empty.", nameof(value));
            Value = value;
        }
    }
}
