namespace EduCore.Application.Abstractions.Models
{
    public sealed record AuthenticationResponse(
        string Token,
        string RefreshToken,
        Guid userId
    );
}
