using Microsoft.AspNetCore.Http;

namespace RealEstate.Application.DTOs.PropertyImage
{
    public class PropertyImageDto
    {
        public int ImageId { get; set; }
        public string Url { get; set; }
        public int PropertyId { get; set; }
        public IFormFile Image { get; set; } = null!;  
    }
}
