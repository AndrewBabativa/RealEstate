namespace RealEstate.Common.Contracts.Property.Filters
{
    public class PropertyFilter
    {
        public string? Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? Year { get; set; }
    }
}
