namespace EduCore.Domain.Roles
{
    public sealed record IsSystemRole
    { 
        public bool Value { get; init; }
        public static readonly IsSystemRole Yes = new IsSystemRole(true);
        public static readonly IsSystemRole No = new IsSystemRole(false);
        private IsSystemRole(bool value)
        {
            Value = value;
        }

        private IsSystemRole() { }

        public static implicit operator bool(IsSystemRole isSystemRole) => isSystemRole.Value;

        public override string ToString() => Value ? "System Role" : "Custom Role";
    }
}
