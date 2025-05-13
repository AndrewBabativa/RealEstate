using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Core.Entities
{
    public class PropertyEntity
    {
        public int PropertyId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = null!;
        public int Year { get; set; }
        public int OwnerId { get; set; }
        public OwnerEntity Owner { get; set; } = null!;
        public ICollection<PropertyImageEntity> Images { get; set; } = new List<PropertyImageEntity>();
        public ICollection<PropertyTraceEntity> Traces { get; set; } = new List<PropertyTraceEntity>();
    }
}
