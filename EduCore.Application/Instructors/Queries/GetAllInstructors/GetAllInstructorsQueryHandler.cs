using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Instructors;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Instructors.Queries.GetAllInstructors
{
    internal sealed class GetAllInstructorsQueryHandler : IQueryHandler<GetAllInstructorsQuery, GetAllDataResponse<InstructorsResponse>>
    {
        private readonly IInstructorRepository _instructorRepository;

        public GetAllInstructorsQueryHandler(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<Result<GetAllDataResponse<InstructorsResponse>>> Handle(GetAllInstructorsQuery request, CancellationToken cancellationToken)
        {
            var allinstructors = await _instructorRepository.GetAllQueryable(cancellationToken)
                .Include(u => u.User)
                .ThenInclude(r => r.Role)
                .OrderByDescending(x => x.Id)
                .ToListAsync(cancellationToken);
            var filteredInstructors = allinstructors.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.Trim().ToLower();
                filteredInstructors = filteredInstructors.Where(x =>
                    (x.User.FullName.ToString() != null && x.User.FullName.ToString().ToLower().Contains(search)) ||
                    (x.User.Email?.Value != null && x.User.Email.Value.ToLower().Contains(search)) ||
                    (x.Specialization?.Value is not null && x.Specialization.Value.ToLower().Contains(search))
                );
            }
            var totalCount = filteredInstructors.Count();
            var pagedData = filteredInstructors
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(instructor => new InstructorsResponse(
                    instructor.Id,
                    instructor.User.FullName.ToString(),
                    instructor.User.Email.Value,
                    instructor.User.PhoneNumber.Value,
                    instructor.User.Gender,
                    instructor.Specialization.Value,
                    instructor.User.Role.Name.Value,
                    instructor.User.CreatedAt
                )).ToList();
            var response = new GetAllDataResponse<InstructorsResponse>
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
