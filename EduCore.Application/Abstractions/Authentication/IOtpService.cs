namespace EduCore.Application.Abstractions.Authentication
{
    public interface IOtpService
    {
        Task<string> GenerateAndSaveOtpAsync(string Email, CancellationToken cancellationToken = default);
        Task<bool> VerifyOtpAsync(string Email , string code, CancellationToken cancellationToken = default);
    }
}