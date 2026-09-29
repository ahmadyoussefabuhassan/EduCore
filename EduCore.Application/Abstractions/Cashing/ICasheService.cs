namespace EduCore.Application.Abstractions.Cashing
{
    public interface ICasheService
    {
        Task<T?> GetAsync<T>(string key , CancellationToken cancellation = default);
        Task SetAsync<T>(string key , T value , CancellationToken cancellation = default);
        Task RemoveAsync(string key , CancellationToken cancellation = default);
    }
}