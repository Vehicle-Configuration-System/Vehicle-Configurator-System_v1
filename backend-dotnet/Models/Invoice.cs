
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("invoice")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("invoice_id")]
        public int InvoiceId { get; set; }

        [Column("invoice_date")]
        public DateTime InvoiceDate { get; set; }

        [Column("model_id")]
        public int ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public VehicleModel? VehicleModel { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("total_amount")]
        public double TotalAmount { get; set; }

        [Column("tax")]
        public double Tax { get; set; }

        [Column("final_amount")]
        public double FinalAmount { get; set; }

        // Navigation Property
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
            = new List<InvoiceDetail>();
    }
}
