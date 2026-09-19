namespace EduCore.Application.Abstractions.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId , string FullName , string email , string role , string jit);
    }
}
