using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Services;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Students;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Students.Queries.GetProfileStudent
{
    internal sealed class GetProfileStudentQueryHandler : BaseService,
        IQueryHandler<GetProfileStudentQuery, StudentResponse>
    {
        private readonly IStudentRepository _studentRepository;
        public GetProfileStudentQueryHandler(IHttpContextAccessor httpContextAccessor, IStudentRepository studentRepository) : base(httpContextAccessor)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result<StudentResponse>> Handle(GetProfileStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(UserId, cancellationToken);
            if(student is null && student?.User is null)
                return Result.Failure<StudentResponse>(StudentErrors.NotFound);
            var response = new StudentResponse(
                student.User.FirstName.Value,
                student.User.LastName.Value,
                student.User.FullName.ToString(),
                student.User.Email.Value,
                student.User.PhoneNumber.Value,
                student.User.Gender,
                student.User.Address.Value,
                student.User.ImageUrl?.Value ?? string.Empty,
                student.Status,
                student.User.CreatedAt,
                student.RegistrationDate
            );
            return Result.Success(response);
        }
    }
}
