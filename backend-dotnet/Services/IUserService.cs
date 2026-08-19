using backend_dotnet.DTO;

namespace backend_dotnet.Services
{
    public interface IUserService
    {
        // Register New User
        Task<string> RegisterAsync(RegisterRequestDto registerDto);

        // Login User
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginDto);

        // Get User By Id
        Task<UserResponseDto?> GetUserByIdAsync(int userId);

        // Get All Users
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();

        // Delete User
        Task<bool> DeleteUserAsync(int userId);
    }
}
