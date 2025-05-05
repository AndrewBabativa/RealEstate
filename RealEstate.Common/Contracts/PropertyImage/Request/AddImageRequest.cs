using Microsoft.AspNetCore.Http;

namespace RealEstate.Common.Contracts.Auth.Request
{
    public class AddImageRequest
    {
        public int PropertyId { get; set; }
        public IFormFile Image { get; set; }
    }
}

