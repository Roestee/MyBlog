using Microsoft.AspNetCore.Http;

namespace MyBlog.Business.Abstract
{
    public interface IFileService
    {
        Task<string> FileSaveAsync(IFormFile file, string path, string folderName);
        Task<string> FileSaveToFtpAsync(IFormFile file);
        Task<byte[]> DownloadFileFromFtpAsync(string url);
        Task DeleteFile(string url);
    }
}
