namespace RealEstate.Application.DTOs.Property
{
    public class CreatePropertyDto
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = null!;
        public int Year { get; set; }
        public int OwnerId { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}