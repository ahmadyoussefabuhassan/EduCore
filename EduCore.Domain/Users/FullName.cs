namespace EduCore.Domain.Users
{
    public sealed record FullName(FirstName FirstName, LastName LastName)
    {
        public override string ToString() => $"{FirstName} {LastName}";
        public string Initials => $"{FirstName.Value[0]}{LastName.Value[0]}".ToUpper();
    }
}
