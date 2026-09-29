using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Services;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.SuperAdmin.Queries.GetProfileSuperAdmin
{
    internal sealed class GetProfileSuperAdminQueryHandler : BaseService, IQueryHandler<GetProfileSuperAdminQuery,SuperAdminResponse>
    {
        private readonly IUserRepository _userRepository;
        public GetProfileSuperAdminQueryHandler(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository) : base(httpContextAccessor)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<SuperAdminResponse>> Handle(GetProfileSuperAdminQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(UserId, cancellationToken);
            if (user is null)
                return Result.Failure<SuperAdminResponse>(UserErrors.NotFound);
            var response = new SuperAdminResponse(
                user.Id,
                user.FirstName,
                user.LastName,
                user.FullName.ToString(),
                user.Email.Value,
                user.PhoneNumber.Value,
                user.Gender,
                user.Address.Value,
                user.ImageUrl?.Value ?? string.Empty,
                user.Role.Name.Value,
                user.CreatedAt
            );
            return Result.Success(response);
        }
    }
}
