using EduCore.Application.Abstractions.Models;

namespace EduCore.Application.Abstractions.Authentication
{
    public interface IRefreshTokenService
    {
        Task<RefreshTokenCacheModel> CreateAndSaveTokenAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}