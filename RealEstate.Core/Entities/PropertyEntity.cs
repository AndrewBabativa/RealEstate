using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Core.Entities
{
    public class PropertyEntity
    {
        public int PropertyId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Address { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string CodeInternal { get; set; } = null!;

        [Required]
        public int Year { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public OwnerEntity Owner { get; set; } = null!;

        public ICollection<PropertyImageEntity> Images { get; set; } = new List<PropertyImageEntity>();

        public ICollection<PropertyTraceEntity> Traces { get; set; } = new List<PropertyTraceEntity>();
    }

}
