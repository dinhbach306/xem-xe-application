using Microsoft.AspNetCore.Http;

namespace XemXe.Application.Services;

public interface IAwsS3Service
{
    Task<string> UploadFileAsync(IFormFile file, string folder, string fileNamePrefix = null);
    Task<List<string>> UploadFilesAsync(List<IFormFile> files, string folder);
    Task<string> GetFileUrlAsync(string key);
}