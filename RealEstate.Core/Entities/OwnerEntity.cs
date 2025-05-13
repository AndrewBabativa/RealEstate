namespace RealEstate.Core.Entities
{
    public class OwnerEntity
    {
        public int OwnerId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Photo { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<PropertyEntity> Properties { get; set; } = new List<PropertyEntity>();
    }
}
