using EduCore.Application.Abstractions.Authentication;
using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Users;

namespace EduCore.Application.Users.VerifyResetCode
{
    internal sealed class VerifyResetCodeCommandHandler : ICommandHandler<VerifyResetCodeCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOtpService _tpService;

        public VerifyResetCodeCommandHandler(IUserRepository userRepository, IOtpService tpService)
        {
            _userRepository = userRepository;
            _tpService = tpService;
        }

        public async Task<Result> Handle(VerifyResetCodeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(new Email(request.Email) , cancellationToken);
            if (user is null)
                return Result.Failure(UserErrors.NotFound);
            bool isValed = await _tpService.VerifyOtpAsync(user.Email.Value , request.Code , cancellationToken);
            if (!isValed)
                return Result.Failure(UserErrors.ResetCodeExpired);
            return Result.Success();
        }
    }
}
