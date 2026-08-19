using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("segment_master")]
    public class Segment
    {
        [Key]
        [Column("segment_id")]
        public int segmentId { get; set; }

        [Column("segment_name")]
        public string segmentName { get; set; } = string.Empty;
    }
}
