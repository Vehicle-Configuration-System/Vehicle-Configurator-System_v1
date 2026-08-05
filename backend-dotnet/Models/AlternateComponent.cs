using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("alternate_component")]
    public class AlternateComponent
    {
        [Key]
        [Column("alt_id")]
        public int AltId { get; set; }


        [Column("model_id")]
        public int ModelId { get; set; }


        [ForeignKey(nameof(ModelId))]
        public VehicleModel? Model { get; set; }


        [Column("comp_id")]
        public int CompId { get; set; }


        [ForeignKey(nameof(CompId))]
        public Component? Component { get; set; }


        [Column("alt_comp_id")]
        public int AltCompId { get; set; }


        [ForeignKey(nameof(AltCompId))]
        public Component? AlternateComponentEntity { get; set; }


        [Required]
        [Column("delta_price")]
        public float DeltaPrice { get; set; }
    }
}
