namespace backend_dotnet.DTO
{
    public class UserResponseDto
    {
        public int UserId { get; set; }

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

        public string Role { get; set; } = string.Empty;
    }
}
