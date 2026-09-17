namespace EduCore.Domain.Users
{
    public sealed record FirstName
    {
        public string Value { get; }
        public FirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("First name cannot be empty.", nameof(value));
            if (value.Length > 50)
                throw new ArgumentException("First name cannot be longer than 50 characters.", nameof(value));
            Value = value;
        }
        public override string ToString() => Value;
        public static implicit operator string(FirstName firstName) => firstName.Value;
        public static explicit operator FirstName(string value) => new(value);
    }
}
