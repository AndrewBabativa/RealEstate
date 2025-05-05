namespace RealEstate.Common.Contracts.Property.Request
{
    public class UpdatePropertyRequest
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public int OwnerId { get; set; }
    }
}
