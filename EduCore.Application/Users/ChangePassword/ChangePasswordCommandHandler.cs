using EduCore.Application.Abstractions.Hashing;
using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Services;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Users.ChangePassword
{
    internal sealed class ChangePasswordCommandHandler : BaseService, ICommandHandler<ChangePasswordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashingService _passwordHashingService;
        public ChangePasswordCommandHandler(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IPasswordHashingService passwordHashingService, IUnitOfWork unitOfWork) : base(httpContextAccessor)
        {
            _userRepository = userRepository;
            _passwordHashingService = passwordHashingService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user =  await _userRepository.GetByIdAsync(UserId, cancellationToken);
            if (user is null)
                return Result.Failure(UserErrors.NotFound);
            if(!_passwordHashingService.VerifyPasswordHash(user.PasswordHash.Value , request.OldPassword))
                return Result.Failure(UserErrors.InvalidOldPassword);
            if (request.NewPassword != request.CheckNewPassword)
                return Result.Failure(UserErrors.InvalidPassword);
            var newpasswordhash = _passwordHashingService.GetPasswordHash(request.NewPassword);
            user.UpdatePasswords(
                new PasswordHash(newpasswordhash)
            );
            await _userRepository.UpdateAsync(user , cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
    }
}
