using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Roles
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role?> GetByNameAsync(Name name, CancellationToken cancellation = default);
    }
}
