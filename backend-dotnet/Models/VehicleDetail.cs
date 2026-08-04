using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("vehicle_detail")]
    public class VehicleDetail
    {
        [Key]
        [Column("config_id")]
        public int ConfigId { get; set; }

        [Column("model_id")]
        public int ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public VehicleModel? Model { get; set; }

        [Column("comp_id")]
        public int CompId { get; set; }

        [ForeignKey(nameof(CompId))]
        public Component? Component { get; set; }

        [Required]
        [Column("comp_type")]
        public string CompType { get; set; } = string.Empty;

        [Required]
        [Column("is_configurable")]
        public string IsConfigurable { get; set; } = string.Empty;
    }
}
