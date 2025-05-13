using Microsoft.AspNetCore.Http;

namespace RealEstate.Application.DTOs.Owner
{
    public class CreateOwnerDto
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public IFormFile? PhotoFile { get; set; }  
        public DateTime Birthday { get; set; }
    }
}