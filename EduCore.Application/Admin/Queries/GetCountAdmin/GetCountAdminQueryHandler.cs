using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Users;

namespace EduCore.Application.Admin.Queries.GetCountAdmin
{
    internal sealed class GetCountAdminQueryHandler : IQueryHandler<GetCountAdminQuery,int>
    {
        private readonly IUserRepository _userRepository;

        public GetCountAdminQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<int>> Handle(GetCountAdminQuery request, CancellationToken cancellationToken)
        {
            var count = await _userRepository.GetCountAdminAsync(cancellationToken);
            return Result.Success(count);
        }
    }
}
