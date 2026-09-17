namespace EduCore.Domain.Users
{
    public sealed record LastName
    {
        public string Value { get; init; }
        public LastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Last name cannot be empty.", nameof(value));
            if (value.Length > 50)
                throw new ArgumentException("Last name cannot be longer than 50 characters.", nameof(value));
            Value = value;
        }
        public override string ToString() => Value;
        public static implicit operator string(LastName lastName) => lastName.Value;
        public static explicit operator LastName(string value) => new(value);
    }
}
