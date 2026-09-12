namespace EduCore.Domain.Sessions
{
    public sealed record Title
    {
        public string Value { get; init; }
        public Title(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Title cannot be empty.", nameof(value));
            Value = value;
        }
    }
}
