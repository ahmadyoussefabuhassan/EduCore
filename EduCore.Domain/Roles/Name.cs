namespace EduCore.Domain.Roles
{
    public sealed record Name
    {
        public string Value { get; init; }
        public readonly static Name SuperAdmin = new Name("SuperAdmin");
        public readonly static Name Admin = new Name("Admin");
        public readonly static Name Instructor = new Name("Instructor");
        public readonly static Name Student = new Name("Student");
        private Name()
        {
            Value = string.Empty;
        }
        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Role name cannot be empty.");
            Value = value;
        }
        public static readonly IReadOnlyCollection<Name> All = new[]
        {
            SuperAdmin,
            Admin,
            Instructor,
            Student
        };
        public static Name FromName(string name)
        {
            return All.FirstOrDefault(n => n.Value.Equals(name, StringComparison.OrdinalIgnoreCase))
                ?? throw new ArgumentException($"The role name {name} is invalid");
        }
    }
}
