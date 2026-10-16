using EduCore.Application.Abstractions.Authentication;
using EduCore.Application.Abstractions.Email;
using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Users;

namespace EduCore.Application.Users.ForgotPassword
{
    internal sealed class SendResetCodeCommandHandler : ICommandHandler<SendResetCodeCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IOtpService _tpService;

        public SendResetCodeCommandHandler(IUserRepository userRepository, IEmailService emailService, IOtpService tpService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _tpService = tpService;
        }

        public async Task<Result> Handle(SendResetCodeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(new Email(request.Email), cancellationToken);
            if(user is null)
                return Result.Failure(UserErrors.InvalidEmail);
            var resetCode = await _tpService.GenerateAndSaveOtpAsync(user.Email.Value , cancellationToken);
            string subject = "رمز إعادة تعيين كلمة المرور - EduCore";
            string message = $"رمز التحقق الخاص بك هو: {resetCode}. ينتهي خلال 5 دقائق.";
            await _emailService.SandEmailAynce(request.Email, subject, message, cancellationToken);
            return Result.Success();
        }
    }
}
