namespace EduCore.Domain.Sessions
{
    public sealed record Description
    {
        public Description(string value)
        {
            if (string.IsNullOrEmpty(value)) 
                throw new ArgumentNullException("Description cannot be empty.", nameof(value));
            Value = value;
        }

        public string Value { get; init; }
        
    }
}
