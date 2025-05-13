using RealEstate.Application.DTOs.Owner;
using RealEstate.Application.DTOs.PropertyImage;

namespace RealEstate.Application.DTOs.Property
{
    public class PropertyDto
    {
        public int PropertyId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = null!;
        public int Year { get; set; }
        public int OwnerId { get; set; }
        public OwnerDto Owner { get; set; } = null!;
        public List<PropertyImageDto> Images { get; set; } = new();
    }
}