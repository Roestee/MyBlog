using Microsoft.AspNetCore.Http;
using MyBlog.Business.Abstract;
using System;
using System.Net;

namespace MyBlog.Business.Concrete
{
    public class FileManager : IFileService
    {
        private const string FtpUrl = "ftp://ftp.ofistakipsistemi.com.tr";
        private const string FtpFolderName = "documents";
        private const string FtpUserName = "ofistaki";
        private const string FtpPassword = "SSii8501.DD,";

        public async Task<string> FileSaveAsync(IFormFile file, string rootPath)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(rootPath, "images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "~/images/" + fileName;
        }

        public string FileSave(IFormFile file, string filePath)
        {
            var fileFormat = file.FileName.Substring(file.FileName.LastIndexOf("."));
            fileFormat = fileFormat.ToLower();
            var fileName = Guid.NewGuid() + fileFormat;
            var path = Path.Combine(filePath, fileName);
            using (var stream = File.Create(path))
            {

                file.CopyTo(stream);
            }

            return path;
        }

        public async Task<string> FileSaveToFtpAsync(IFormFile file)
        {
            try
            {
                var fileFormat = file.FileName.Substring(file.FileName.LastIndexOf("."));
                fileFormat = fileFormat.ToLower();
                var fileName = Guid.NewGuid() + fileFormat;
                var uri = $"{FtpUrl}/{FtpFolderName}/{fileName}";
                await using (var fileStream = file.OpenReadStream())
                {
                    var request = (FtpWebRequest)WebRequest.Create(new Uri(uri));
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(FtpUserName, FtpPassword);
                    request.UseBinary = true;
                    request.ContentLength = fileStream.Length;

                    const int bufferLength = 2048;
                    var buffer = new byte[bufferLength];

                    await using (var requestStream = await request.GetRequestStreamAsync())
                    {
                        int bytesRead;
                        while ((bytesRead = await fileStream.ReadAsync(buffer, 0, bufferLength)) != 0)
                            await requestStream.WriteAsync(buffer, 0, bytesRead);
                    }

                    using (var response = (FtpWebResponse)await request.GetResponseAsync())
                    {
                        if (response.StatusCode == FtpStatusCode.ClosingData)
                            return uri;

                        Console.WriteLine("Dosya yükleme hatası: " + response.StatusDescription);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            return "";
        }

        public async Task<byte[]> DownloadFileFromFtpAsync(string ftpUrl)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(new Uri(ftpUrl));
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(FtpUserName, FtpPassword);
                request.UseBinary = true;

                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                using (Stream responseStream = response.GetResponseStream())
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await responseStream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return null;
            }
        }

        public async Task DeleteFile(string url)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                request.Credentials = new NetworkCredential(FtpUserName, FtpPassword);

                using (var response = (FtpWebResponse)request.GetResponse())
                    Console.WriteLine($"Delete status: {response.StatusDescription}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }
    }
}
