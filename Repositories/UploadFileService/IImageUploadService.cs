using Microsoft.AspNetCore.Http;

namespace Repositories.UploadFileService;

public interface IImageUploadService
{
    Task<List<string>> UploadFiles(ICollection<IFormFile> files);
    
    Task<string> UploadFile(IFormFile files, Guid imageId);
}