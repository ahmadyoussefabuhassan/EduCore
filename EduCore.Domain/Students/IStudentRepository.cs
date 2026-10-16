using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Students
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<int> GetCountAsync(CancellationToken cancellationToken = default);
    }
}
