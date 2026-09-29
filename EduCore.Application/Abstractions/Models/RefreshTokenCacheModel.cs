namespace EduCore.Application.Abstractions.Models
{
    public sealed record RefreshTokenCacheModel(    
        Guid Id,
        Guid userId,
        string token,
        string? DeviceInfo,
        string? IPAddress,
        bool IsRevoked,
        DateTime CreatedAt,
        DateTime ExpiresAt
    );
}
