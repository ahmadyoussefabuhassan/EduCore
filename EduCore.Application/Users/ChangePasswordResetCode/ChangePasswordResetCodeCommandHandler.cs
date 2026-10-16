using EduCore.Application.Abstractions.Authentication;
using EduCore.Application.Abstractions.Hashing;
using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Users;

namespace EduCore.Application.Users.ChangePasswordResetCode
{
    internal sealed class ChangePasswordResetCodeCommandHandler : ICommandHandler<ChangePasswordResetCodeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IOtpService _tpService;
        private readonly IPasswordHashingService _passwordHashingService;

        public ChangePasswordResetCodeCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IOtpService tpService, IPasswordHashingService passwordHashingService)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _tpService = tpService;
            _passwordHashingService = passwordHashingService;
        }

        public async Task<Result> Handle(ChangePasswordResetCodeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(new Email(request.Email), cancellationToken);
            if (user is null)
                return Result.Failure(UserErrors.InvalidEmail);
            var restcode = await _tpService.VerifyOtpAsync(user.Email.Value, request.Code, cancellationToken);
            if(!restcode)
                return Result.Failure(UserErrors.InvalidResetCode);
            var passwordhash = _passwordHashingService.GetPasswordHash(request.Password);
            user.UpdatePasswords(
                new PasswordHash(passwordhash)
            );
            await _userRepository.UpdateAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
