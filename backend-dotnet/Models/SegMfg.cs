using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("seg_mfg_master")]
    public class SegMfg
    {
        [Key]
        [Column("seg_mfg_id")]
        public int SegMfgId { get; set; }

        [Column("segment_id")]
        public int SegmentId { get; set; }

        [ForeignKey(nameof(SegmentId))]
        public Segment? Segment { get; set; }

        [Column("manufacturer_id")]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer? Manufacturer { get; set; }
    }
}
