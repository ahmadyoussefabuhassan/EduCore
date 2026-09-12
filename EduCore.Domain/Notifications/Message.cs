namespace EduCore.Domain.Notifications
{
    public sealed record Message
    {
        public string Value { get; init; }
        public Message(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Message cannot be empty.", nameof(value));
            Value = value;
        }
    }
}
