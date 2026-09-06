namespace EduCore.Domain.Users
{
    public sealed record PasswordResetCode(string code)
    {
        public static PasswordResetCode Generate() =>
             new(new Random().Next(1000, 9999).ToString());
    }
}
