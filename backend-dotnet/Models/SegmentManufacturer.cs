using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("segment_manufacturer")]
    public class SegmentManufacturer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("segment_id")]
        public int SegmentId { get; set; }

        [ForeignKey(nameof(SegmentId))]
        public Segment? Segment { get; set; }

        [Column("manufacturer_id")]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer? Manufacturer { get; set; }

        public ICollection<Model> Models { get; set; } = new List<Model>();
    }
}
