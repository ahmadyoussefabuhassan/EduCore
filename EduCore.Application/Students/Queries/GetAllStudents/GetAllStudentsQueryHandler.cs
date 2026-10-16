using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Students;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Students.Queries.GetAllStudents
{
    internal sealed class GetAllStudentsQueryHandler : IQueryHandler<GetAllStudentsQuery, GetAllDataResponse<StudentsResponse>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result<GetAllDataResponse<StudentsResponse>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var allstudents = await _studentRepository.GetAllQueryable(cancellationToken)
                .Include(u => u.User)
                .ThenInclude(r => r.Role)
                .OrderByDescending(x => x.Id)
                .ToListAsync(cancellationToken);
            var filteredstudents = allstudents.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.Trim().ToLower();
                filteredstudents = filteredstudents.Where(x =>
                   (x.User.FullName.ToString() != null && x.User.FullName.ToString().ToLower().Contains(search)) ||
                   (x.User.Email?.Value != null && x.User.Email.Value.ToLower().Contains(search))
                );
            }
            var totalCount = filteredstudents.Count();
            var pagedData = filteredstudents
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(student => new StudentsResponse(
                    student.Id,
                    student.User.FullName.ToString(),
                    student.User.Email.Value,
                    student.User.PhoneNumber.Value,
                    student.User.Gender,
                    student.Status,
                    student.User.Role.Name.Value,
                    student.User.CreatedAt,
                    student.RegistrationDate
                )).ToList();
            var response = new GetAllDataResponse<StudentsResponse>
            {
                PageNumber = request.PageNumber,
                TotalDateCount = totalCount,
                TotalPage = (int)Math.Ceiling(totalCount / (double)request.PageSize),
                Data = pagedData
            };
            return Result.Success(response);
        }
    }
}
