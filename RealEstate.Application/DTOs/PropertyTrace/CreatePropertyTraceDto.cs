namespace RealEstate.Application.DTOs.PropertyTrace
{
    public class CreatePropertyTraceDto
    {
        public int PropertyId { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; } = null!;
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
    }
}