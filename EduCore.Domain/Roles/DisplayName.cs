namespace EduCore.Domain.Roles
{
    public sealed record DisplayName
    {
        public string Value { get; init; }
        private DisplayName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Display name cannot be empty.");
            Value = value;
        }
        public static DisplayName GetDefault(Name roleName) => roleName.Value switch
        {
            "SuperAdmin" => new DisplayName("مدير النظام"),
            "Admin" => new DisplayName("مسؤول"),
            "Instructor" => new DisplayName("مدرب"),
            "Student" => new DisplayName("طالب"),
            _ => new DisplayName(roleName.Value)
        };

        public override string ToString() => Value;
    }
}
