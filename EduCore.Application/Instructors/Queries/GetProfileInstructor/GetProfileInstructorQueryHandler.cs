using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Services;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Instructors;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Instructors.Queries.GetProfileInstructor
{
    internal sealed class GetProfileInstructorQueryHandler : BaseService,
        IQueryHandler<GetProfileInstructorQuery, InstructorResponse>
    {
        private readonly IInstructorRepository _instructorRepository;
        public GetProfileInstructorQueryHandler(IHttpContextAccessor httpContextAccessor, IInstructorRepository instructorRepository) : base(httpContextAccessor)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<Result<InstructorResponse>> Handle(GetProfileInstructorQuery request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorRepository.GetByIdAsync(UserId, cancellationToken);
            if (instructor is null && instructor?.User is null)
                return Result.Failure<InstructorResponse>(InstructorErrors.NotFound);
            var response = new InstructorResponse(
                instructor.User.FirstName.Value,
                instructor.User.LastName.Value,
                instructor.User.FullName.ToString(),
                instructor.User.Email.Value,
                instructor.User.PhoneNumber.Value,
                instructor.User.Gender,
                instructor.User.Address.Value,
                instructor.User.ImageUrl?.Value ?? string.Empty,
                instructor.Specialization.Value,
                instructor.User.CreatedAt
            );
            return Result.Success(response);
        }
    }
}
