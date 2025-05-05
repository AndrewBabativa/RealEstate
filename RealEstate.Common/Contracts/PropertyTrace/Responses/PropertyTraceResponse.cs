namespace RealEstate.Common.Contracts.PropertyTrace.Responses
{
    public class PropertyTraceResponse
    {
        public int Id { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
    }

}
