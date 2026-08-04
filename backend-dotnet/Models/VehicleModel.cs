using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("vehicle_model")]
    public class VehicleModel
    {
        [Key]
        [Column("model_id")]
        public int ModelId { get; set; }

        [Column("manufacturer_id")]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer? Manufacturer { get; set; }

        [Column("segment_id")]
        public int SegmentId { get; set; }

        [ForeignKey(nameof(SegmentId))]
        public Segment? Segment { get; set; }

        [Required]
        [Column("model_name")]
        [MaxLength(100)]
        public string ModelName { get; set; } = string.Empty;

        [Required]
        [Column("image")]
        [MaxLength(100)]
        public string Image { get; set; } = string.Empty;

        [Column("base_price")]
        public float BasePrice { get; set; }

        [Column("minimum_quantity")]
        public int MinimumQuantity { get; set; }

        // Navigation Properties
        public ICollection<VehicleDetail> VehicleDetails { get; set; } = new List<VehicleDetail>();

        public ICollection<AlternateComponent> AlternateComponents { get; set; } = new List<AlternateComponent>();
    }
}
