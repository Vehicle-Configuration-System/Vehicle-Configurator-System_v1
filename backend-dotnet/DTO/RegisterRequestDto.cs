using System.ComponentModel.DataAnnotations;

namespace backend_dotnet.DTO
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "Company Name is required")]
        [StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Company Address is required")]
        [StringLength(500)]
        public string CompanyAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mobile Number is required")]
        [Phone(ErrorMessage = "Invalid Mobile Number")]
        [StringLength(10, MinimumLength = 10)]
        public string Mobile { get; set; } = string.Empty;

        [Required(ErrorMessage = "GST Number is required")]
        [StringLength(20)]
        public string GstNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Registration Number is required")]
        [StringLength(50)]
        public string RegistrationNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "ST Number is required")]
        [StringLength(50)]
        public string StNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "VAT Number is required")]
        [StringLength(50)]
        public string VatNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tax Number is required")]
        [StringLength(50)]
        public string TaxNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Designation is required")]
        [StringLength(50)]
        public string Designation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password should be at least 6 characters")]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
