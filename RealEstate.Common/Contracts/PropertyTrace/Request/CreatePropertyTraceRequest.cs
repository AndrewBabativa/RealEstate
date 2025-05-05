namespace RealEstate.Common.Contracts.PropertyTrace.Request
{
    public class CreatePropertyTraceRequest
    {
        public int PropertyId { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
    }

}
