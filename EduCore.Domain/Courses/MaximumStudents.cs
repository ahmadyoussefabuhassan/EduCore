namespace EduCore.Domain.Courses
{
    public sealed record MaximumStudents
    {
        public short Value { get; init; }
        public MaximumStudents(short value)
        {
            if (value <= 0)
                throw new ArgumentException("Maximum students must be greater than zero.", nameof(value));
            Value = value;
        }
    }
}
