using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Students;

namespace EduCore.Application.Students.Queries.GetCountStudent
{
    internal sealed class GetCountStudentQueryHandler : IQueryHandler<GetCountStudentQuery, int>
    {
        private readonly IStudentRepository _studentRepository;

        public GetCountStudentQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result<int>> Handle(GetCountStudentQuery request, CancellationToken cancellationToken)
        {
            var countstudent = await _studentRepository.GetCountAsync(cancellationToken);
            return Result.Success(countstudent);
        }
    }
}
