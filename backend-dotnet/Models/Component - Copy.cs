using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Models
{
    [Table("component")]
    public class LoginRequest
    {
        [Key]
        [Column("comp_id")]
        public int CompId { get; set; }

        [Required]
        [Column("comp_name")]
        public string CompName { get; set; } = string.Empty;
    }
}
