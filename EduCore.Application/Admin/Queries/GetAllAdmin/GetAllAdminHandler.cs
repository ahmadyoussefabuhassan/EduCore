using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Users;

namespace EduCore.Application.Admin.Queries.GetAllAdmin
{
    internal sealed class GetAllAdminHandler : IQueryHandler<GetAllAdminQuery, IEnumerable<AdminResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllAdminHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<AdminResponse>>> Handle(GetAllAdminQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);
            if (!users.Any())
                return Result.Success(Enumerable.Empty<AdminResponse>());
            var response = users.Select(u => new AdminResponse(
                u.Id,
                u.FirstName,
                u.LastName,
                u.FullName.ToString(),
                u.Email.Value,
                u.PhoneNumber.Value,
                u.Gender,
                u.Address.Value,
                u.ImageUrl?.Value ?? string.Empty
            ));
            return Result.Success(response);
        }
    }
}
