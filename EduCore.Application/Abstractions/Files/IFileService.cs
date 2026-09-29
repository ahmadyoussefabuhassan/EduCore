using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Abstractions.Files
{
    public interface IFileService
    {
        Task<string> UploadImageAsync(IFormFile file, string folderName, CancellationToken cancellationToken = default);
        FileStream GetImageProvider(string path);
        void DeleteImage(string imagePath);
    }
}
