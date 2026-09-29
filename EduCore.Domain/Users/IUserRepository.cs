using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken);

        Task<User?> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken);
        Task<int> GetCountAdminAsync(CancellationToken cancellationToken);
        Task<int> GetCountSuperAdminAsync(CancellationToken cancellationToken);
    }
}
