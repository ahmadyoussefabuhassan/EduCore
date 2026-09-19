namespace EduCore.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task SandEmailAynce(string to, string subject, string body, CancellationToken cancellation = default);
    }
}