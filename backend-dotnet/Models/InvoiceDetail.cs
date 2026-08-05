using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("invoice_detail")]
    public class InvoiceDetail
    {
        [Key]
        [Column("invoice_detail_id")]
        public int InvoiceDetailId { get; set; }

        [Column("invoice_id")]
        public int InvoiceId { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public Invoice? Invoice { get; set; }

        // Original Component
        [Column("component_id")]
        public int ComponentId { get; set; }

        [ForeignKey(nameof(ComponentId))]
        public LoginRequest? Component { get; set; }

        // Selected Alternate Component
        [Column("alternate_component_id")]
        public int AlternateComponentId { get; set; }

        [ForeignKey(nameof(AlternateComponentId))]
        public LoginRequest? AlternateComponent { get; set; }

        [Column("delta_price")]
        public double DeltaPrice { get; set; }
    }
}
