using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("model_master")]
    public class Model
    {
        [Key]
        [Column("model_id")]
        public int ModelId { get; set; }

        [Column("mdl_name")]
        public string MdlName { get; set; } = string.Empty;

        [Column("sm_id")]
        public int SegmentManufacturerId { get; set; }

        [ForeignKey(nameof(SegmentManufacturerId))]
        public SegmentManufacturer? SegmentManufacturer { get; set; }

        [Column("min_qty_price")]
        public double MinQtyPrice { get; set; }

        [Column("image_path")]
        public string ImagePath { get; set; } = string.Empty;
    }
}
