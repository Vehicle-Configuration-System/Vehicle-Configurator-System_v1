using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("manufacturer_master")]
    public class Manufacturer
    {
        [Key]
        [Column("manufacturer_id")]
        public int ManufacturerId { get; set; }

        [Column("manufacturer_name")]
        public string ManufacturerName { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<SegMfg> SegMfgs { get; set; } = new List<SegMfg>();
    }
}
