namespace RealEstate.Common.Contracts.PropertyImage.Responses
{
    public class PropertyImageResponse
    {
        public int PropertyImageId { get; set; }
        public string Url { get; set; } = null!;
        public bool Enabled { get; set; }
    }
}
