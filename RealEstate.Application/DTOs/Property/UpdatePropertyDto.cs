namespace RealEstate.Application.DTOs.Property
{
    public class UpdatePropertyDto
    {
        public int PropertyId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string CodeInternal { get; set; } = null!;
        public int Year { get; set; }
        public int OwnerId { get; set; }
    }
}
