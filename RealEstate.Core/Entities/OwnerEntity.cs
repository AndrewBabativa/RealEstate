using System.ComponentModel.DataAnnotations;

namespace RealEstate.Core.Entities
{
    public class OwnerEntity
    {
        public int OwnerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Address { get; set; } = null!;

        [MaxLength(255)]
        public string? Photo { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public ICollection<PropertyEntity> Properties { get; set; } = new List<PropertyEntity>();
    }

}
