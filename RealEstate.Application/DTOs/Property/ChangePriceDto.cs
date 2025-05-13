namespace RealEstate.Application.DTOs.Property
{
    public class ChangePriceDto
    {
        public int PropertyId { get; set; }
        public decimal NewPrice { get; set; }
    }
}
