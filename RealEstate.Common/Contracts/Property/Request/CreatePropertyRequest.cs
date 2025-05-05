namespace RealEstate.Common.Contracts.Property.Request
{
    public class CreatePropertyRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public int OwnerId { get; set; }

        public List<string>? ImageUrls { get; set; }
    }
}