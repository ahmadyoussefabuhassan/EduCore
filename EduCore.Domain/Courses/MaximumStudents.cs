namespace EduCore.Domain.Courses
{
    public sealed record MaximumStudents
    {
        public int Value { get; init; }
        public MaximumStudents(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Maximum students must be greater than zero.", nameof(value));
            Value = value;
        }
    }
}
