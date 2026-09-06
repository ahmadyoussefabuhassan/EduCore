using System.Text.RegularExpressions;

namespace EduCore.Domain.Users
{
    public sealed record PhoneNumber
    {
        public string Value { get; init; }
        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone number cannot be null or empty.", nameof(value));
            if (!Regex.IsMatch(value, @"^\+?\d+$"))
                throw new ArgumentException("Phone number format is invalid, it must contain only digits and an optional '+' at the beginning");
            this.Value = value;
        }
    }
}
