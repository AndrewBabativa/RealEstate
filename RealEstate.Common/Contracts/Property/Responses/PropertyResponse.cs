using RealEstate.Common.Contracts.Owner.Responses;
using RealEstate.Common.Contracts.PropertyImage.Responses;

namespace RealEstate.Common.Contracts.Property.Responses
{
    public class PropertyResponse
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public int OwnerId { get; set; }
        public OwnerResponse Owner { get; set; }
        public List<PropertyImageResponse> Images { get; set; } = new();
    }
}
