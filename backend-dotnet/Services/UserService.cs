using backend_dotnet.DTO;
using backend_dotnet.Models;
using backend_dotnet.Repository;

namespace backend_dotnet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // ===========================
        // Register User
        // ===========================
        public async Task<string> RegisterAsync(RegisterRequestDTO registerDto)
        {
            // Check Email
            if (await _userRepository.EmailExistsAsync(registerDto.Email))
            {
                return "Email already exists.";
            }

            // Check Username
            if (await _userRepository.UsernameExistsAsync(registerDto.Username))
            {
                return "Username already exists.";
            }

            // Create User Entity
            User user = new User
            {
                CompanyName = registerDto.CompanyName,
                CompanyAddress = registerDto.CompanyAddress,
                Username = registerDto.Username,
                Email = registerDto.Email,
                Mobile = registerDto.Mobile,
                GstNo = registerDto.GstNo,
                RegistrationNo = registerDto.RegistrationNo,
                StNo = registerDto.StNo,
                VatNo = registerDto.VatNo,
                TaxNo = registerDto.TaxNo,
                Designation = registerDto.Designation,

                // NOTE:
                // For testing only.
                // Replace with password hashing before implementing login.
                Password = registerDto.Password,

                Role = "ROLE_USER"
            };

            await _userRepository.RegisterUserAsync(user);

            return "Registration Successful";
        }

        // ===========================
        // Not Implemented Yet
        // ===========================

        public Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDTO?> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}