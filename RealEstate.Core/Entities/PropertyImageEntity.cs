namespace RealEstate.Core.Entities
{
    public class PropertyImageEntity
    {
        public int PropertyImageId { get; set; }
        public int PropertyId { get; set; }
        public string Url { get; set; } 
        public bool Enabled { get; set; }
        public PropertyEntity Property { get; set; } = null!;
    }
}
