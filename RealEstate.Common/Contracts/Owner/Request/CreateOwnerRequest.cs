using Microsoft.AspNetCore.Http;

namespace RealEstate.Common.Contracts.Owner.Request
{
    public class CreateOwnerRequest
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public IFormFile? Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
