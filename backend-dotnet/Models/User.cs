using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("company_name")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Column("company_address")]
        [MaxLength(500)]
        public string CompanyAddress { get; set; } = string.Empty;

        [Required]
        [Column("username")]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Column("email")]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("mobile")]
        [MaxLength(10)]
        public string Mobile { get; set; } = string.Empty;

        [Required]
        [Column("gst_no")]
        [MaxLength(20)]
        public string GstNo { get; set; } = string.Empty;

        [Required]
        [Column("registration_no")]
        [MaxLength(50)]
        public string RegistrationNo { get; set; } = string.Empty;

        [Required]
        [Column("st_no")]
        [MaxLength(50)]
        public string StNo { get; set; } = string.Empty;

        [Required]
        [Column("vat_no")]
        [MaxLength(50)]
        public string VatNo { get; set; } = string.Empty;

        [Required]
        [Column("tax_no")]
        [MaxLength(50)]
        public string TaxNo { get; set; } = string.Empty;

        [Required]
        [Column("designation")]
        [MaxLength(50)]
        public string Designation { get; set; } = string.Empty;

        [Required]
        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column("role")]
        public string Role { get; set; } = "ROLE_USER";
    }
}
