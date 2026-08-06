using backend_dotnet.DTO;
using backend_dotnet.Helpers;
using backend_dotnet.Models;
using backend_dotnet.Repository;

namespace backend_dotnet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public UserService(
            IUserRepository userRepository,
            PasswordHasher passwordHasher,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }
        // ===========================
        // Register User
        // ===========================
        public async Task<string> RegisterAsync(RegisterRequestDto registerDto)
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
                Password = _passwordHasher.HashPassword(registerDto.Password),
                Role = "ROLE_USER"
            };

            await _userRepository.RegisterUserAsync(user);

            return "Registration Successful";
        }

        // ===========================
        // Not Implemented Yet
        // ===========================

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginDto)
        {
            // Find user by email
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Invalid Email"
                };
            }

            // Verify password
            bool isPasswordValid =
                _passwordHasher.VerifyPassword(
                    loginDto.Password,
                    user.Password);

            if (!isPasswordValid)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Invalid Password"
                };
            }

            // Generate JWT Token
            string token = _jwtService.GenerateToken(user);

            // Return Response
            return new LoginResponseDto
            {
                Success = true,
                Message = "Login Successful",

                Token = token,

                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
        }

        public Task<UserResponseDto?> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
