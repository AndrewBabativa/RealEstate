using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using RealEstate.Core.Contracts;

namespace RealEstate.Infrastructure.Storage
{
    public class CloudinaryService : IDocumentStorageService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(string cloudName, string apiKey, string apiSecret)
        {
            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);  
        }

        public async Task<string> UploadImageAsync(IFormFile imageFile)
        {
            if (imageFile.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(stream);
                    stream.Position = 0;

                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(imageFile.FileName, stream),
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return uploadResult.SecureUrl.ToString();  
                    }
                }
            }

            throw new ArgumentException("Invalid image file");
        }

    }
}
