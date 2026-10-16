using EduCore.Application.Abstractions.Cashing;
using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;

namespace EduCore.Application.Users.LogOut
{
    internal sealed class LogOutCommandHandler : ICommandHandler<LogOutCommand>
    {
        private readonly ICasheService _casheService;

        public LogOutCommandHandler(ICasheService casheService)
        {
            _casheService = casheService;
        }

        public async Task<Result> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.refreshtoken))
                return Result.Failure(new Error("Auth.InvalidRefreshToken", "التوكن غير صالح."));
            string key = $"refresh-token:{request.refreshtoken}";
            await _casheService.RemoveAsync(key, cancellationToken);
            return Result.Success();
        }
    }
}
