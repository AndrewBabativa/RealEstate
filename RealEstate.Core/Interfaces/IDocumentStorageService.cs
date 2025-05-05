using Microsoft.AspNetCore.Http;

namespace RealEstate.Core.Contracts
{
    public interface IDocumentStorageService
    {
        Task<string> UploadImageAsync(IFormFile imagePath);
    }
}


