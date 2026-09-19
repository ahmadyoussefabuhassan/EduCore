namespace EduCore.Application.Abstractions.Hashing
{
    public interface IPasswordHashingService
    {
        string GetPasswordHash(string password);
        bool VerifyPasswordHash(string password, string passwordHash);
    }
}