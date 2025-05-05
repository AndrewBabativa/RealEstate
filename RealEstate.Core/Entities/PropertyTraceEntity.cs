using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Core.Entities
{
    public class PropertyTraceEntity
    {
        public int PropertyTraceId { get; set; }

        [Required]
        public DateTime DateSale { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }

        [Required]
        public int PropertyId { get; set; }

        public PropertyEntity Property { get; set; } = null!;
    }

}
