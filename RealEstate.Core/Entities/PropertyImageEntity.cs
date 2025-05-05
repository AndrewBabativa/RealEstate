using System.ComponentModel.DataAnnotations;

namespace RealEstate.Core.Entities
{
    public class PropertyImageEntity
    {
        public int PropertyImageId { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Url { get; set; } = null!;

        [Required]
        public bool Enabled { get; set; }

        public PropertyEntity Property { get; set; } = null!;
    }

}
