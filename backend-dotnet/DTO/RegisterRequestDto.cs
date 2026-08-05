namespace backend_dotnet.DTOs
{
    public class RegisterRequestDto
    {
        public string CompanyName { get; set; } = string.Empty;

        public string CompanyAddress { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string GstNo { get; set; } = string.Empty;

        public string RegistrationNo { get; set; } = string.Empty;

        public string StNo { get; set; } = string.Empty;

        public string VatNo { get; set; } = string.Empty;

        public string TaxNo { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        // Plain password from user
        public string Password { get; set; } = string.Empty;
    }
}