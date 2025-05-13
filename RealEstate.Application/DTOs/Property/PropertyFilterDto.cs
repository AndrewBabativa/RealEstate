namespace RealEstate.Application.DTOs.Property
{
    public class PropertyFilterDto
    {
        public string? Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? Year { get; set; }
    }
}