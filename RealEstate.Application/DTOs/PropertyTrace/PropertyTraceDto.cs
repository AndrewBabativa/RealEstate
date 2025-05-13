namespace RealEstate.Application.DTOs.PropertyTrace
{
    public class PropertyTraceDto
    {
        public int Id { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; } = null!;
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
    }
}