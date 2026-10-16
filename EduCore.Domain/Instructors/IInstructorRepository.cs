using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Instructors
{
    public interface IInstructorRepository : IRepository<Instructor>
    {
        Task<bool> HasRelatedDataAsync(Guid instructorId, CancellationToken cancellationToken = default);
        Task<int> GetCountInstructorAsync(CancellationToken cancellationToken = default);
    }
}
