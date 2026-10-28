namespace EduCore.Domain.Abstractions
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IQueryable<TEntity>> GetAllQueryableAsync(CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetAllQueryable(CancellationToken cancellationToken = default);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid Id, CancellationToken cancellationToken = default);
        void Delete(Guid Id);
    }
}
