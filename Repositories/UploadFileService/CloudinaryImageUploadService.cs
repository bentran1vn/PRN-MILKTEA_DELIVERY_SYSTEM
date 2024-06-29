using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Repositories.UploadFileService;

public class CloudinaryImageUploadService : IImageUploadService
{
    const string Cloud = "dejf8mmou";
    const string ApiKey = "871315156277625";
    const string ApiSecret = "5BmSeWjASNxfXldgTr6oIjdjSio";

    private readonly Cloudinary _cloudinary;

    public CloudinaryImageUploadService()
    {
        var account = new Account(Cloud, ApiKey, ApiSecret);
        _cloudinary = new Cloudinary(account);
        _cloudinary.Api.Secure = true;
    }

    public async Task<List<string>> UploadFiles(ICollection<IFormFile> files)
    {
        var imageUrls = new List<string>();           

        foreach (var file in files)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var uploadparams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, memoryStream),
            };

            var result = _cloudinary.Upload(uploadparams);

            if (result.Error != null)
            {
                throw new Exception($"Cloudinary error occured: {result.Error.Message}");
            }

            imageUrls.Add(result.SecureUrl.ToString());
        }
        return imageUrls;
    }

    public async Task<string> UploadFile(IFormFile file, Guid imageId)
    {
        using var memoryStream = new MemoryStream();
        
        await file.CopyToAsync(memoryStream);
        
        memoryStream.Position = 0;

        var uploadparams = new ImageUploadParams()
        {
            File = new FileDescription(file.FileName, memoryStream),
            PublicId = imageId.ToString()
        };

        var result = _cloudinary.Upload(uploadparams);

        if (result.Error != null)
        {
            throw new Exception($"Cloudinary error occured: {result.Error.Message}");
        }

        return result.SecureUrl.ToString();
    }
}