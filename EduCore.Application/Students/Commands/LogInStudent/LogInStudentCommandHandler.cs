using EduCore.Application.Abstractions.Authentication;
using EduCore.Application.Abstractions.Hashing;
using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Models;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Roles;
using EduCore.Domain.Users;

namespace EduCore.Application.Students.Commands.LogInStudent
{
    internal sealed class LogInStudentCommandHandler : ICommandHandler<LogInStudentCommand, AuthenticationResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IPasswordHashingService _passwordHashingService;

        public LogInStudentCommandHandler(IUserRepository userRepository,
            IJwtTokenGenerator tokenGenerator,
            IRefreshTokenService refreshTokenService,
            IPasswordHashingService passwordHashingService)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _refreshTokenService = refreshTokenService;
            _passwordHashingService = passwordHashingService;
        }

        public async Task<Result<AuthenticationResponse>> Handle(LogInStudentCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(new Email(request.Email), cancellationToken);
            if(user is null)
                return Result.Failure<AuthenticationResponse>(UserErrors.InvalidEmail);
            if(!_passwordHashingService.VerifyPasswordHash(request.Password, user.PasswordHash.Value))
                return Result.Failure<AuthenticationResponse>(UserErrors.InvalidPassword);
            if (user.Role is null)
                return Result.Failure<AuthenticationResponse>(RoleErrors.NotFound);
            if (user.Role.Name.Value != Name.Student.Value)
                return Result.Failure<AuthenticationResponse>(UserErrors.Unauthorized);
            var token = _tokenGenerator.GenerateToken(user.Id,
                user.FullName.ToString(),
                user.Email.Value,
                user.Role.Name.Value,
                Guid.NewGuid().ToString()
            );
            var refreshtoken = await _refreshTokenService.CreateAndSaveTokenAsync(user.Id, cancellationToken);
            var response = new AuthenticationResponse(token, refreshtoken.token, user.Id);
            return Result.Success(response);
        }
    }
}
