namespace EduCore.Domain.Users
{
    public sealed record PasswordHash
    {
        public string Value { get; init; }
        public PasswordHash(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password cannot be null or empty.", nameof(value));
            if (value.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters long.", nameof(value));
            Value = value;
        }
    }
}
