using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Services;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Admin.Queries.GetProfileAdmin
{
    internal sealed class GetProfileAdminQueryHandler : BaseService, IQueryHandler<GetProfileAdminQuery, AdminResponse>
    {
        private readonly IUserRepository _userRepository;
        public GetProfileAdminQueryHandler(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository) : base(httpContextAccessor)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<AdminResponse>> Handle(GetProfileAdminQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(UserId , cancellationToken);
            if(user is null)
                return Result.Failure<AdminResponse>(UserErrors.NotFound);
            var response = new AdminResponse(
                user.Id,
                user.FirstName,
                user.LastName,
                user.FullName.ToString(),
                user.Email.Value,
                user.PhoneNumber.Value,
                user.Gender,
                user.Address.Value,
                user.ImageUrl?.Value  ?? string.Empty,  
                user.Role.Name.Value,
                user.CreatedAt
            );
            return Result.Success(response);
        }
    }
}
