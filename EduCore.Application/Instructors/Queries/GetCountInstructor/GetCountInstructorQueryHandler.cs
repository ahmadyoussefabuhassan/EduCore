using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Instructors;

namespace EduCore.Application.Instructors.Queries.GetCountInstructor
{
    internal sealed class GetCountInstructorQueryHandler : IQueryHandler<GetCountInstructorQuery, int>
    {
        private readonly IInstructorRepository _instructorRepository;

        public GetCountInstructorQueryHandler(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<Result<int>> Handle(GetCountInstructorQuery request, CancellationToken cancellationToken)
        {
            var countinstructors = await _instructorRepository.GetCountInstructorAsync(cancellationToken);
            return Result.Success(countinstructors);
        }
    }
}
