using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Core.Entities
{
    public class PropertyTraceEntity
    {
        public int PropertyTraceId { get; set; }
        public DateTime DateSale { get; set; }

        public string Name { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }

        public int PropertyId { get; set; }

        public PropertyEntity Property { get; set; } = null!;
    }

}
