using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("invoice")]
    public class Invoice
    {
        [Key]
        [Column("invoice_id")]
        public int InvoiceId { get; set; }

        // Navigation Property
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    }
}
