using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace XemXe.Application.Services;

public class AwsS3Service : IAwsS3Service
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;
    
    public AwsS3Service(IAmazonS3 s3Client, IConfiguration configuration)
    {
        _s3Client = s3Client;
        _bucketName = configuration["AWS:BucketName"] ?? throw new ArgumentNullException("AWS:BucketName not configured");
    }
    
    public async Task<string> UploadFileAsync(IFormFile file, string folder, string fileNamePrefix = null)
    {
        var fileName = $"{fileNamePrefix ?? Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
        var key = $"{folder}/{fileName}";
        var transferUtility = new TransferUtility(_s3Client);
        
        using (var stream = file.OpenReadStream())
        {
            await transferUtility.UploadAsync(stream, _bucketName, key);
        }

        return $"https://{_bucketName}.s3.amazonaws.com/{key}";
    }

    public async Task<List<string>> UploadFilesAsync(List<IFormFile> files, string folder)
    {
        var urls = new List<string>();
        foreach (var file in files)
        {
            var url = await UploadFileAsync(file, folder);
            urls.Add(url);
        }

        return urls;
    }

    public async Task<string> GetFileUrlAsync(string key)
    {
        return await Task.FromResult($"https://{_bucketName}.s3.amazonaws.com/{key}");
    }
}