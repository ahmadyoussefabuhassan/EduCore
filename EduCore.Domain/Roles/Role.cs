using EduCore.Domain.Abstractions;
using EduCore.Domain.Users;

namespace EduCore.Domain.Roles
{
    public sealed class Role : Entity
    {
        private Role(Guid Id, Name name, DisplayName displayName, IsSystemRole isSystemRole) : base(Id)
        {
            Name = name;
            DisplayName = displayName;
            IsSystemRole = isSystemRole;
        }
        public Name Name { get; private set; }
        public DisplayName DisplayName { get; private set; }
        public IsSystemRole IsSystemRole { get; private set; }
        public ICollection<User> Users { get; private set; } = new List<User>();
        public static Role CreateSystemRole(Name name)
        {
            var role = new Role(Guid.NewGuid(), name, DisplayName.GetDefault(name), IsSystemRole.Yes);
            return role;
        }
        public static Role CreateCustomRole(Name name)
        {
            var role = new Role(Guid.NewGuid(), name, DisplayName.GetDefault(name), IsSystemRole.No);
            return role;
        }

    }
}
