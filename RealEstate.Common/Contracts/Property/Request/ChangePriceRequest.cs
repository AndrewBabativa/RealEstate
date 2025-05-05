namespace RealEstate.Common.Contracts.Property.Request
{
    public class ChangePriceRequest
    {
        public int PropertyId { get; set; }
        public decimal NewPrice { get; set; }
    }
}
